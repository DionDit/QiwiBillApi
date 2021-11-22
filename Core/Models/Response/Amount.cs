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
        public Amount(double Value, string Currency)
        {
            if (Value > 0)
            {
                if (!string.IsNullOrWhiteSpace(Currency))
                {
                    this.Value = Value;
                    this.Currency = Currency;
                }
                else
                {
                    throw new Exception("Unknown currency!");
                }
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
