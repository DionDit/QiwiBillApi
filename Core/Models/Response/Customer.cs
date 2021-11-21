using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QiwiBillApi.Core.Models.Response
{
    [DataContract]
    public class Customer
    {
        [DataMember(Name = "phone")]
        public string Phone { get; private set; }
        [DataMember(Name = "email")]
        public string Email { get; private set; }
        [DataMember(Name = "account")]
        public string Account { get; private set; }

        public Customer(string Phone, string Email, string Account)
        {
            if (!string.IsNullOrWhiteSpace(Phone) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Account))
            {
                this.Phone = Phone;
                this.Email = Email;
                this.Account = Account;
            }
            else
            {
                throw new Exception("Incorrect data!");
            }
        }
        public Customer()
        {

        }
    }
}
