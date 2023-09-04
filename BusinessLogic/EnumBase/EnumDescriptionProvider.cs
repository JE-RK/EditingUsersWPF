using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EnumBase
{
    public class EnumDescriptionProvider : IEnumDescriptionProvider
    {
        public string GetDescription<T>(T value) where T : Enum
        {
            var type = value.GetType();
            var fi = type.GetField(value.ToString());
            var name = fi.GetCustomAttribute<DescriptionAttribute>()?.Description ?? value.ToString();
            return name;
        }
    }
}
