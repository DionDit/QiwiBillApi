using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiwiBillApi.Core.Models
{
    public static class Extensions
    {
        public static string GetDescription(this Enum Element) => (Element.GetType().GetMember(Element.ToString())[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0] as DescriptionAttribute).Description;
    }
}
