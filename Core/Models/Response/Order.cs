using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace QiwiBillApi.Core.Models.Response
{
    [DataContract]
    public class Order
    {
        public string BillId { get; private set; }
        [DataMember(Name = "customer")]
        public Customer Customer { get; private set; }
        [DataMember(Name = "expirationDateTime")]
        public string ExpirationDateTime { get; private set; }
        [DataMember(Name = "amount")]
        public Amount Amount { get; private set; }
        [DataMember(Name = "comment")]
        public string Comment { get; private set; }

        public Order(Amount amount, Customer customer, string comment, DateTime expirationDateTime)
        {
            BillId = Guid.NewGuid().ToString();
            this.Amount = amount;
            this.Customer = customer;
            this.Comment = comment;
            this.ExpirationDateTime = expirationDateTime.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffzzz");
        }
        public Order()
        {
            BillId = Guid.NewGuid().ToString();
        }
        public static string CreateOrderStringJSON(Order Order)
        {
            DataContractJsonSerializer Json = new DataContractJsonSerializer(typeof(Order));
            using (MemoryStream MemoryStream = new MemoryStream())
            {
                using (StreamReader StreamReader = new StreamReader(MemoryStream))
                {
                    Json.WriteObject(MemoryStream, Order);
                    MemoryStream.Position = 0;
                    return StreamReader.ReadToEnd();
                }
            }
        }
        public static Order CreateOrderFromJSON(string OrderJSON)
        {
            DataContractJsonSerializer Json = new DataContractJsonSerializer(typeof(Order));
            using (MemoryStream MemoryStream = new MemoryStream(Encoding.Unicode.GetBytes(OrderJSON)))
            {
                return Json.ReadObject(MemoryStream) as Order;
            }
        }
    }
}
