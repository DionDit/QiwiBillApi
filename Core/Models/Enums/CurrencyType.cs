using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QiwiBillApi.Core.Models
{
    public enum CurrencyType
    {
        /// <summary>
        /// Российский рубль
        /// </summary>
        [Description("RUB")]
         RUB,

        /// <summary>
        /// Казахстанский тенге
        /// </summary>
        [Description("KZT")]
        KZT
    }
}
