using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EnumBase
{
    public interface IEnumDescriptionProvider
    {
        string GetDescription<T>(T value) where T : Enum;
    }
}
