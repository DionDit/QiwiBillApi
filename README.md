# Welcome to QiwiBillApi

Hi! This project allows you to easily and quickly create invoices for payment, and get up-to-date information about them using the API.


# Authorization
To use the API, you need `SecretKey` 
```c#
var SecretKey = "48e7qUxn9T7RyYE1MVZswX1FRSbE6iyCj2gCRwwF3Dnh5XrasNTx3BGPiMsyXQFNKQhvukniQG8RTVhYm3iP5Pzvzs11ExoMqi3oiRqm94v8FGS7BYDhTqW9o8VGcksn4UtFKm6pUeVKkL6Eh6oB••••••••••••••••";
var Qiwi = new Qiwi(SecretKey);
```

# Creating a payment bill

`After authorization, you can start creating an invoice for payment.`
```c#
Qiwi.CreateOrder(new Order(new Amount(10, CurrencyType.RUB),
new Customer("+7 (812) 976‒50‒50", "info@qiwiapi.ru", "id1"),
"TestBill",
DateTime.Now.AddDays(2)));
```
`After the object is created, JSON is created and sent to the server`
```
{"amount":{"currency":"RUB","value":10},"comment":"TestBill","customer":{"account":"id1","email":"info@qiwiapi.ru","phone":"+7 (812) 976?50?50"},"expirationDateTime":"2021-11-23T15:04:57.303+07:00"}
```
`After the order is created, information about this invoice is returned.`
```
{"siteId":"6qppaw-00","billId":"c9e76336-e17d-4d0d-96b7-cd41ec2b1c04","amount":{"currency":"RUB","value":"10.00"},"status":{"value":"WAITING","changedDateTime":"2021-11-21T11:11:22.427+03:00"},"customer":{"account":"id1","email":"info@qiwiapi.ru","phone":"+7 (812) 976?50?50"},"comment":"TestBill","creationDateTime":"2021-11-21T11:11:22.427+03:00","expirationDateTime":"2021-11-23T11:11:22.452+03:00","payUrl":"https://oplata.qiwi.com/form/?invoice_uid=4c55ded3-2e2e-4b4d-a2cc-8ac6b4318a45"}
```
# Getting information about the payment bill
`To do this, you need BillId`
```c#
var OrderInfo = Qiwi.OrderGetInfo(BillId);
Console.WriteLine($"SiteId: {OrderInfo.SiteId}\nBillId: {OrderInfo.BillId}\nAmount: Value:{OrderInfo.Amount.Value} Currency: {OrderInfo.Amount.Currency}\nStatus: Value: {OrderInfo.Status.Value} ChangedDateTime: {OrderInfo.Status.ChangedDateTime}\nCustomer: Email: {OrderInfo.Customer.Email} Phone: {OrderInfo.Customer.Phone} Account: {OrderInfo.Customer.Account}\nComent: {OrderInfo.Comment}\nCreationDateTime: {OrderInfo.CreationDateTime}\nExpirationDateTime: {OrderInfo.ExpirationDateTime}\nUrl: {OrderInfo.Url}");
```
![enter image description here](https://sun9-10.userapi.com/impg/AxEXZr9_hfbZ3DK7og-Ol2cEfRp5SSZkg0Lbtw/5AH42HhwJCc.jpg?size=682x147&quality=96&sign=ad1214da19b6f7dd62284b560235ebfe&type=album)
# Cancellation of an invoice
``BillId is also required to cancel an invoice``
```c#
var RejectedOrder = Qiwi.RejectOrder("f6257803-d960-43b0-a935-393092cd8144");
Console.WriteLine($"SiteId: {RejectedOrder.SiteId}\nBillId: {RejectedOrder.BillId}\nAmount: Value:{RejectedOrder.Amount.Value} Currency: {RejectedOrder.Amount.Currency}\nStatus: Value: {RejectedOrder.Status.Value} ChangedDateTime: {RejectedOrder.Status.ChangedDateTime}\nCustomer: Email: {RejectedOrder.Customer.Email} Phone: {RejectedOrder.Customer.Phone} Account: {RejectedOrder.Customer.Account}\nComent: {RejectedOrder.Comment}\nCreationDateTime: {RejectedOrder.CreationDateTime}\nExpirationDateTime: {RejectedOrder.ExpirationDateTime}\nUrl: {RejectedOrder.Url}");
```
``As a result, the account information is returned``
![enter image description here](https://sun9-57.userapi.com/impg/owokwnz_5UdXfcjIGeNqFYi2_xmU5ZFANlpAgw/_IJ4CXX8WwA.jpg?size=686x149&quality=96&sign=888e4f058a427379c85ed0a6f6d77ce3&type=album)
# Events
``To use events, you need to add an event handler``
```c#
Qiwi.OnPaidOrderAction += OrderPaid;

private static void OrderPaid()
{
    Console.WriteLine($"The order is paid");
}
```
``Now in order for the event to be called, you need to call the CheckStatus method.
For example, you can use this:``

```c#
var Order = Qiwi.OrderGetInfo(BillId);
await Task.Run(() =>
{
    while (true)
    {
        await Task.Delay(1000);
        Console.WriteLine(Qiwi.CheckStatus(Order));
    }
});
```
