using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModelEnumBase
{
    public interface IEnumValuesProvider
    {
        IEnumerable<ModesViewModel<TEnum>> GetValues<TEnum>() where TEnum : Enum;
    }
}
