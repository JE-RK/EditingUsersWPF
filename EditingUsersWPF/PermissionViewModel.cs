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
        private ObservableCollection<ModesViewModel<Modes>> modesEnum;


        public PermissionViewModel(Permission permission, IEnumValuesProvider enumProvider) { 
            this.permission = permission;
            modesEnum = enumProvider.GetValues<Modes>().ToObservableCollection();
            module = permission.Module;
        }
        public ObservableCollection<ModesViewModel<Modes>> ModesEnum
        {
            get { return modesEnum; }
            set
            {
                modesEnum = value;
                OnPropertyChanged("ModesEnum");
            }
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
