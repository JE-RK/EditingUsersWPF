using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersWPF.ViewModels.ViewModelEnumBase
{
    public class ModesViewModel<TEnum> where TEnum : Enum
    {
        public TEnum Value { get; set; }
        public string Description { get; }

        public ModesViewModel(TEnum value, string description)
        {
            Value = value;
            Description = description;
        }
    }
}
