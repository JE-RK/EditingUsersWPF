using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BusinessLogic;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.IO;
using EditingUsersDAL;
using User = BusinessLogic.User;
using EditingUsersWPF.ViewModels.EnumBase;
using EditingUsersWPF.ViewModels.ViewModelEnumBase;
using Permission = BusinessLogic.Permission;
using System.Collections;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Documents;

namespace EditingUsersWPF
{
    public class ApplicationViewModel : NotifyPropertyChangedBaseClass
    {
        IRepository<User> repositoryUsers;
        PostgreSQLModelsRepository repositoryModules;
        PermissionRepository repositoryPermissions;
        private UserViewModel selectedUser;
        private byte[] userPhoto;
        public List<Module> Modules;
        public ObservableCollection<UserViewModel> UserViewModelList  { get; set; } = new ObservableCollection<UserViewModel>();

        public UserViewModel SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        public ApplicationViewModel()
        {
            repositoryModules = new PostgreSQLModelsRepository();
            Modules = repositoryModules.GetUserList().ToList();
            repositoryUsers = new PostgreSQLUserRepository();
            repositoryPermissions = new PermissionRepository();
            UserViewModelList = repositoryUsers.GetUserList().Select(b => 
            new UserViewModel(b, new EnumValuesProvider(new EnumDescriptionProvider()))).ToObservableCollection();
        }
         

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        repositoryUsers.Create(selectedUser.user);
                        repositoryUsers.Save();
                    }));
            }
        }

        private RelayCommand addEmptyUserCommand;
        public RelayCommand AddEmptyUserCommand
        {
            get
            {
                return addEmptyUserCommand ??
                    (addEmptyUserCommand = new RelayCommand(obj =>
                    {
                        User user = new User();
                        user.Permissions = new List<Permission>
                        {
                            new Permission { Id = Guid.NewGuid(), UserId = user.Id, Mode = BusinessLogic.Modes.View, ModuleId = Modules[0].Id },
                            new Permission { Id = Guid.NewGuid(), UserId = user.Id, Mode = BusinessLogic.Modes.View, ModuleId = Modules[1].Id },
                            new Permission { Id = Guid.NewGuid(), UserId = user.Id, Mode = BusinessLogic.Modes.View, ModuleId = Modules[2].Id },
                            new Permission { Id = Guid.NewGuid(), UserId = user.Id, Mode = BusinessLogic.Modes.View, ModuleId = Modules[3].Id }
                        };
                        UserViewModelList.Add(new UserViewModel(user, new EnumValuesProvider(new EnumDescriptionProvider())));    
                    }));
            }
        }
    }
}
