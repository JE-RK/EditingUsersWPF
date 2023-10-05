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
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using Catel;
using System.Globalization;
using System.Windows.Forms;

namespace EditingUsersWPF
{
    public class ApplicationViewModel : NotifyPropertyChangedBaseClass
    {
        ApplicationDBContext db;
        IRepository<User> repositoryUsers;
        ModuleRepository repositoryModules;
        PermissionRepository repositoryPermissions;
        private UserViewModel selectedUser;
        private byte[] userPhoto;
        public List<Module> Modules;
        private ObservableCollection<UserViewModel> userViewModelList;
        public ObservableCollection<UserViewModel> UserViewModelList
        {
            get { return userViewModelList; }
            set
            {
                userViewModelList = value;
                OnPropertyChanged("UserViewModelList");
            }
        }

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
            db = new ApplicationDBContext();
            repositoryModules = new ModuleRepository();
            Modules = repositoryModules.GetUserList().ToList();
            repositoryUsers = new UserRepository();
            repositoryPermissions = new PermissionRepository();
            UserViewModelList = repositoryUsers.GetItemList().Select(b => 
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

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        repositoryUsers.Delete(selectedUser.user.Id);
                        repositoryUsers.Save();
                    }));
            }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        repositoryUsers.Delete(selectedUser.user.Id);
                        userViewModelList.Remove(selectedUser);
                        repositoryUsers.Save();
                    }));
            }
        }

        string pattern;
        public string Pattern
        {
            get => pattern;
            set
            {
                pattern = value;
                if (Pattern == "")
                {
                    UserViewModelList = repositoryUsers.GetItemList().Select(b =>
                        new UserViewModel(b, new EnumValuesProvider(new EnumDescriptionProvider()))).ToObservableCollection();
                }
                else if(pattern.Length > 3)
                {
                    DateTime dateValue;
                    Thread thread;
                    if (DateTime.TryParse(pattern, out dateValue))
                    {
                        thread = new Thread(_ =>
                        {
                            var searchusers = db.Users.Where(u => u.Birthday == dateValue).Include(x => x.Permissions).ToList();
                            UserViewModelList = searchusers.Select(b =>
                                new UserViewModel(b, new EnumValuesProvider(new EnumDescriptionProvider()))).ToObservableCollection();
                        });
      
                    }
                    else
                    {
                        thread = new Thread(_ =>
                        {
                            Thread.Sleep(2000);

                            var searchusers = db.Users.FromSqlRaw($"select * from \"Users\" where concat_ws(' ', \"LastName\", \"FirstName\") ilike N'%{pattern}%' or concat_ws(' ', \"FirstName\", \"LastName\") ilike N'%{pattern}%'").Include(x => x.Permissions).ToList();
                            UserViewModelList = searchusers.Select(b =>
                                new UserViewModel(b, new EnumValuesProvider(new EnumDescriptionProvider()))).ToObservableCollection();
                        });
                        
                    }
                    thread.Start();
                }
                
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
                        foreach (var module in Modules)
                        {
                            user.Permissions.Add(new Permission { Id = Guid.NewGuid(), UserId = user.Id, Mode = BusinessLogic.Modes.View, ModuleId = module.Id });
                        }
                        UserViewModelList.Add(new UserViewModel(user, new EnumValuesProvider(new EnumDescriptionProvider())));    
                    }));
            }
        }
    }
}
