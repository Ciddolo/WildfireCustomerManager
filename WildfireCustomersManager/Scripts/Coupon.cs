using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildfireCustomersManager
{
    public class Coupon
    {
        public float InitialValue;
        public float CurrentValue;
        public bool Expire;
        public DateTime EmissionDate;
        public DateTime ExpireDate;
        public bool IsValid { get { return Expire ? DateTime.Now.Date < ExpireDate && CurrentValue > 0.0f : CurrentValue > 0.0f; } }

        public Coupon(float value, DateTime emissionDate, bool expire)
        {
            InitialValue = value;
            CurrentValue = value;
            Expire = expire;
            EmissionDate = emissionDate.Date;
            if (expire)
                ExpireDate = emissionDate.AddDays(90.0d);
            else
                ExpireDate = DateTime.MaxValue.Date;
        }

        public float UseCoupon(float toPay)
        {
            if (!IsValid)
                return toPay;

            CurrentValue -= toPay;

            if (CurrentValue >= 0.0f)
                return 0.0f;
            else
            {
                toPay = CurrentValue * -1;
                CurrentValue = 0.0f;
                return toPay;
            }
        }

        public bool IsAboutToExpire()
        {
            return (ExpireDate - DateTime.Now).TotalDays < 7.0d;
        }
    }
}
