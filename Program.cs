using QiwiBillApi.Core.Models;
using QiwiBillApi.Core.Models.Enums;
using QiwiBillApi.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiwiBillApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Qiwi Qiwi = new Qiwi("eyJ2ZXJzaW9uIjoiUDJQIiwiZGF0YSI6eyJwYXlpbl9tZXJjaGFudF9zaXRlX3VpZCI6IjZxcHBhdy0wMCIsInVzZXJfaWQiOiI3OTEzODE1MTYwNyIsInNlY3JldCI6ImVjYWM0ZjBiOTJiYWUwYjBkOWRiNmYxOGViOWIyZDM0YmNiMjA0YzI4YWQxYmM4ZWU3Y2ZjOTE5OTQzNjI4MjMifX0=");
            var RejectedOrder = Qiwi.OrderGetInfo("11aa6981-3ae4-48ec-ba20-ef798e5282f9");
            Console.WriteLine($"SiteId: {RejectedOrder.SiteId}\nBillId: {RejectedOrder.BillId}\nAmount: Value:{RejectedOrder.Amount.Value} Currency: {RejectedOrder.Amount.Currency}\nStatus: Value: {RejectedOrder.Status.Value} ChangedDateTime: {RejectedOrder.Status.ChangedDateTime}\nCustomer: Email: {RejectedOrder.Customer.Email} Phone: {RejectedOrder.Customer.Phone} Account: {RejectedOrder.Customer.Account}\nComent: {RejectedOrder.Comment}\nCreationDateTime: {RejectedOrder.CreationDateTime}\nExpirationDateTime: {RejectedOrder.ExpirationDateTime}\nUrl: {RejectedOrder.Url}");
            Console.WriteLine(RejectedOrder.Amount.CurrencyType);
        }
    }
}
