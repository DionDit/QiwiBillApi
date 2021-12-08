using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QiwiBillApi.Core.Models.Response
{
    [DataContract]
    public class Amount
    {
        [DataMember(Name = "value")]
        public double Value { get; private set; }
        [DataMember(Name = "currency")]
        public string Currency { get; private set; }
        public CurrencyType CurrencyType
        {
            get
            {
                var Type = CurrencyType.RUB;
                switch (Currency)
                {
                    case "RUB":
                        Type = CurrencyType.RUB;
                        break;
                    case "KZT":
                        Type = CurrencyType.KZT;
                        break;
                }
                return Type;
            }
        }
        public Amount(double Value, CurrencyType Currency)
        {
            if (Value > 0)
            {
                this.Value = Value;
                this.Currency = Currency.GetDescription();
            }
            else
            {
                throw new Exception("Value cannot be less than or equal to zero!");
            }
        }
        public Amount()
        {

        }
    }
}
