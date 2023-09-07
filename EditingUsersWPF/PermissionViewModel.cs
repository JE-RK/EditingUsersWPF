using BusinessLogic;
using BusinessLogic.ViewModelEnumBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EditingUsersWPF
{
    public class PermissionViewModel : NotifyPropertyChangedBaseClass
    {
        Permission permission;
        Modules module;
        private ObservableCollection<ModesViewModel<Modes>> ModesEnum { get; }
        
        public PermissionViewModel(Permission permission, IEnumValuesProvider enumProvider) { 
            this.permission = permission;
            ModesEnum = enumProvider.GetValues<Modes>().ToObservableCollection();
            module = permission.Module;
        }

        public Modes SelectedMode
        {
            get { return permission.Mode; }
            set
            {
                permission.Mode = value;
                OnPropertyChanged("SelectedMode");
            }
        }
        public string ModuleName
        {
            get { return module.Name; }
            set
            {
                module.Name = value;
                OnPropertyChanged("ModuleName");
            }
        }
    }
}
