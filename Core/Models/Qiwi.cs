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

        private void SetHeaders(WebClient WebClient)
        {
            WebClient.Encoding = Encoding.UTF8;
            WebClient.Headers[HttpRequestHeader.Authorization] = $"Bearer {SecretKey}";
            WebClient.Headers[HttpRequestHeader.Accept] = "application/json";
            WebClient.Headers[HttpRequestHeader.ContentType] = "application/json";
        }

        public OrderInfo OrderGetInfo(string BillId)
        {
            using (WebClient WebClient = new WebClient())
            {
                SetHeaders(WebClient);
                return OrderInfo.CreateOrderInfoFromJSON(WebClient.DownloadString($"https://api.qiwi.com/partner/bill/v1/bills/{BillId}"));
            }

        }
        public async Task<OrderInfo> OrderGetInfoAsync(string BillId) => await Task.Run(() => OrderGetInfo(BillId));

        public OrderInfo CreateOrder(Order Order)
        {
            using (WebClient WebClient = new WebClient())
            {
                SetHeaders(WebClient);
                WebClient.UploadString($"https://api.qiwi.com/partner/bill/v1/bills/{Order.BillId}", WebRequestMethods.Http.Put, Order.CreateOrderStringJSON(Order));
                return OrderInfo.CreateOrderInfoFromJSON(WebClient.DownloadString($"https://api.qiwi.com/partner/bill/v1/bills/{Order.BillId}"));
            }
        }
        public async Task<OrderInfo> CreateOrderAsync(Order Order) => await Task.Run(() => CreateOrder(Order));

        public OrderInfo RejectOrder(string BillId)
        {
            using (WebClient WebClient = new WebClient())
            {
                SetHeaders(WebClient);
                return OrderInfo.CreateOrderInfoFromJSON(WebClient.UploadString($"https://api.qiwi.com/partner/bill/v1/bills/{BillId}/reject", WebRequestMethods.Http.Post, ""));
            }
        }
        public async Task<OrderInfo> RejectOrderAsync(string BillId) => await Task.Run(() => RejectOrder(BillId));
    }
}
