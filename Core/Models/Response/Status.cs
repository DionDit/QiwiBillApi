using QiwiBillApi.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QiwiBillApi.Core.Models.Response
{
    [DataContract]
    public class Status
    {
        [DataMember(Name = "value")]
        public string Value { get; private set; }
        [DataMember(Name = "changedDateTime")]
        public DateTime ChangedDateTime { get; private set; }
        public InvoicePaymentType InvoicePaymentType
        {
            get
            {
                var Type = InvoicePaymentType.WAITING;
                switch (Value)
                {
                    case "WAITING":
                        Type = InvoicePaymentType.WAITING;
                        break;
                    case "EXPIRED":
                        Type = InvoicePaymentType.EXPIRED;
                        break;
                    case "PAID":
                        Type = InvoicePaymentType.PAID;
                        break;
                    case "REJECTED":
                        Type = InvoicePaymentType.REJECTED;
                        break;
                }
                return Type;
            }
        }
    }
}
