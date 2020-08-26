using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WildfireCustomersManager
{
    public class Customer
    {
        public string Name;
        public string Surname;
        public string Email;
        public string TelephoneNumber;
        public string Points;
        public List<Coupon> ValidCoupons = new List<Coupon>();
        public List<Coupon> ExpiredCoupons = new List<Coupon>();
        public float Balance;
        public string Notes;

        public Customer(string name, string surname, string email = "", string telephoneNumber = "", string points = "0.0", float balance = 0.0f, string notes = "")
        {
            Name = name;
            Surname = surname;
            Email = email;
            TelephoneNumber = telephoneNumber;
            Points = points;
            Balance = balance;
            Notes = notes;
        }

        public void CalculateDiscount()
        {
            string discount;
            float points = float.Parse(Points);

            if (points >= 2000)
                discount = "20%";
            else if (points >= 1000)
                discount = "15%";
            else if (points >= 500)
                discount = "10%";
            else if (points >= 250)
                discount = "5%";
            else
                discount = "0%";
                
            MessageBox.Show(discount, Name + Surname + "Discount", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public float CalculateBalance()
        {
            float currentValue = 0.0f;

            foreach (Coupon coupon in ValidCoupons)
            {
                if (coupon.IsValid)
                    currentValue += coupon.CurrentValue;
            }

            Balance = currentValue;

            return Balance;
        }

        public void ExpireCoupon(Coupon coupon)
        {
            if (coupon.IsValid)
                return;

            if (ValidCoupons.Contains(coupon))
            {
                ValidCoupons.Remove(coupon);
                ExpiredCoupons.Add(coupon);
            }
        }

        public void CheckValidCoupon()
        {
            int n = ValidCoupons.Count - 1;

            for (int i = n; i >= 0; i--)
                ExpireCoupon(ValidCoupons[i]);
        }

        public Coupon GetNextToExpireCoupon()
        {
            if (ValidCoupons.Count <= 0)
                return null;
            else if (ValidCoupons.Count == 1)
                return ValidCoupons[0];
            else
            {
                Coupon nextToExpireCoupon = ValidCoupons[0];

                for (int i = 1; i < ValidCoupons.Count; i++)
                {
                    if (ValidCoupons[i].ExpireDate < nextToExpireCoupon.ExpireDate)
                        nextToExpireCoupon = ValidCoupons[i];
                }

                return nextToExpireCoupon;
            }
        }

        public void Pay(float price, int cycles = 0)
        {
            float toPay = price;

            if (cycles == 0)
                CheckValidCoupon();

            Coupon currentCoupon = GetNextToExpireCoupon();

            if (currentCoupon == null)
            {
                if (cycles <= 0)
                    MessageBox.Show("No valid coupons!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(String.Format("No more valid coupons! \nCoupons used: {0} \nTo Pay: {1}", cycles, price),
                                                  "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            toPay = currentCoupon.UseCoupon(toPay);
            ExpireCoupon(currentCoupon);

            if (toPay > 0.0f)
                Pay(toPay, ++cycles);
            else
                MessageBox.Show(String.Format("Coupons used succesfully! \nCoupons used: {0}", ++cycles),
                                              "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool CheckCouponsAboutToExpire()
        {
            bool output = false;

            for (int i = 0; i < ValidCoupons.Count; i++)
            {
                if (ValidCoupons[i].IsAboutToExpire())
                {
                    output = true;
                    return output;
                }
            }

            return output;
        }
    }
}
