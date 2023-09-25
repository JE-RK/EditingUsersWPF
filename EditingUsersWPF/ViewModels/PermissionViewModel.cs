using BusinessLogic;
using EditingUsersDAL;
using EditingUsersWPF.ViewModels.EnumBase;
using EditingUsersWPF.ViewModels.ViewModelEnumBase;
using Newtonsoft.Json.Linq;
using Npgsql;
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
        ModuleRepository PostgreSQLModelsRepository;
        Module module;
        EnumDescriptionProvider enumDescription;
        ModesViewModel<Modes> selectedMode;
        private ObservableCollection<ModesViewModel<Modes>> modesEnum;
        public PermissionViewModel(Permission permission) {
            this.permission = permission;
            PostgreSQLModelsRepository = new ModuleRepository();
            module = PostgreSQLModelsRepository.GetUser(permission.ModuleId);
            enumDescription = new EnumDescriptionProvider();
            selectedMode = new ModesViewModel<Modes>(permission.Mode, enumDescription.GetDescription(permission.Mode));
        }

        public ModesViewModel<Modes> SelectedMode
        {
            get { return selectedMode; }
            set
            {
                selectedMode = value;
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
