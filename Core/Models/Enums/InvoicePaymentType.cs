using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiwiBillApi.Core.Models.Enums
{
    public enum InvoicePaymentType
    {
        /// <summary>
        /// Счет выставлен, ожидает оплаты
        /// </summary>
        [Description("WAITING")]
        WAITING,

        /// <summary>
        /// Счет оплачен
        /// </summary>
        [Description("PAID")]
        PAID,

        /// <summary>
        /// Счет отклонен
        /// </summary>
        [Description("REJECTED")]
        REJECTED,

        /// <summary>
        /// Время жизни счета истекло. Счет не оплачен
        /// </summary>
        [Description("EXPIRED")]
        EXPIRED,
    }
}
