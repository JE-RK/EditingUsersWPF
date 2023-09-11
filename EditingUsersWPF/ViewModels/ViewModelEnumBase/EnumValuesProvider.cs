using EditingUsersWPF.ViewModels.EnumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersWPF.ViewModels.ViewModelEnumBase
{
    public class EnumValuesProvider : IEnumValuesProvider
    {
        private readonly IEnumDescriptionProvider _descriptionProvider;

        public EnumValuesProvider(IEnumDescriptionProvider descriptionProvider)
        {
            _descriptionProvider = descriptionProvider;
        }


        public IEnumerable<ModesViewModel<TEnum>> GetValues<TEnum>()
            where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum));
            foreach (TEnum value in values)
            {
                var description = _descriptionProvider.GetDescription(value);
                yield return new ModesViewModel<TEnum>(value, description);
            }
        }
    }
}
