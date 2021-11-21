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
    }
}
