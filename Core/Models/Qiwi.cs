using QiwiBillApi.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QiwiBillApi.Core.Models
{
    public class Qiwi
    {
        public string SecretKey { get; }
        public Qiwi(string SecretKey)
        {
            if (!string.IsNullOrWhiteSpace(SecretKey))
            {
                this.SecretKey = SecretKey;
            }
            else
            {
                throw new Exception("SecretKey can't be empty!");
            }
        }

        public OrderInfo OrderGetInfo(string BillId)
        {
            using (WebClient WebClient = new WebClient())
            {
                WebClient.Encoding = Encoding.Unicode;
                WebClient.Headers[HttpRequestHeader.Authorization] = $"Bearer {SecretKey}";
                WebClient.Headers[HttpRequestHeader.Accept] = "application/json";
                WebClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                return OrderInfo.CreateOrderInfoFromJSON(WebClient.DownloadString($"https://api.qiwi.com/partner/bill/v1/bills/{BillId}"));
            }

        }
        public OrderInfo CreateOrder(Order Order)
        {
            using (WebClient WebClient = new WebClient())
            {
                WebClient.Encoding = Encoding.Unicode;
                WebClient.Headers[HttpRequestHeader.Authorization] = $"Bearer {SecretKey}";
                WebClient.Headers[HttpRequestHeader.Accept] = "application/json";
                WebClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                WebClient.UploadString($"https://api.qiwi.com/partner/bill/v1/bills/{Order.BillId}", WebRequestMethods.Http.Put, Order.CreateOrderStringJSON(Order));
                return OrderInfo.CreateOrderInfoFromJSON(WebClient.DownloadString($"https://api.qiwi.com/partner/bill/v1/bills/{Order.BillId}"));
            }
        }
    }
}
