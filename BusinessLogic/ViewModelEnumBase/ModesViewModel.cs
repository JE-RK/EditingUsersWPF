using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ModesViewModel<TEnum> where TEnum : Enum
    {
        public TEnum Value { get; }
        public string Description { get; }

        public ModesViewModel(TEnum value, string description)
        {
            Value = value;
            Description = description;
        }
    }
}
