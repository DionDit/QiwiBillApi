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
    public class OrderInfo
    {
        [DataMember(Name = "siteId")]
        public string SiteId { get; set; }
        [DataMember(Name = "billId")]
        public string BillId { get; set; }
        [DataMember(Name = "amount")]
        public Amount Amount { get; set; }
        [DataMember(Name = "status")]
        public Status Status { get; set; }
        [DataMember(Name = "customer")]
        public Customer Customer { get; set; }
        [DataMember(Name = "comment")]
        public string Comment { get; set; }
        [DataMember(Name = "creationDateTime")]
        public string CreationDateTime { get; set; }
        [DataMember(Name = "expirationDateTime")]
        public string ExpirationDateTime { get; set; }
        [DataMember(Name = "payUrl")]
        public string Url { get; set; }

        public static OrderInfo CreateOrderInfoFromJSON(string Order)
        {
            var Settings = new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH\\:mm\\:ss.fffzzz")
            };
            DataContractJsonSerializer Json = new DataContractJsonSerializer(typeof(OrderInfo), Settings);
            using (MemoryStream Stream = new MemoryStream(Encoding.Unicode.GetBytes(Order)))
            {
                return Json.ReadObject(Stream) as OrderInfo;
            }
        }
        public static async Task<OrderInfo> CreateOrderInfoFromJSONAsync(string Order) => await Task.Run(() => CreateOrderInfoFromJSON(Order));
    }
}
