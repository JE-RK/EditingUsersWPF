using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using static BusinessLogic.Permission;
using Microsoft.Win32;
using System.Windows.Input;
using EditingUsersWPF;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.IO;
using static BusinessLogic.Modes;
using BusinessLogic.ViewModelEnumBase;
using Microsoft.VisualBasic;
using System.Windows.Controls.Primitives;
using System.Windows;
using EditingUsersDAL;

namespace EditingUsersWPF
{
    public class ApplicationViewModel : NotifyPropertyChangedBaseClass
    {
        private User selectedUser;
        private byte[] userPhoto;
        public List<User> Users { get; set; }
        public List<Modules> Modules;
        public List<Permission> PermissionsList { get; set; }
        public List<Permission> PermissionsList1 { get; set; }
        IUsersProvider usersProvider;


        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        //для комбобокса
        public ObservableCollection<ModesViewModel<Modes>> TestEnum1 { get; }


        public ApplicationViewModel(IEnumValuesProvider enumProvider)
        {
            TestEnum1 = enumProvider.GetValues<Modes>().ToObservableCollection();
            userPhoto = File.ReadAllBytes(@"C:\Users\d-bel\Downloads\kinozpis.jpg");
            usersProvider = new RegisteredUsersProvider();
            Modules = new List<Modules>
            {
                new Modules {Id = Guid.NewGuid(), Name="Продажи"},
                new Modules {Id = Guid.NewGuid(), Name="Закупки"},
                new Modules {Id = Guid.NewGuid(), Name="Аналитика"},
                new Modules {Id = Guid.NewGuid(), Name="Администрирование"},
            };

            PermissionsList = new List<Permission>
            {
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = BusinessLogic.Modes.Admin, ModuleId = Modules[0].Id, Module = Modules[0]},
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = BusinessLogic.Modes.Edit, ModuleId = Modules[1].Id, Module = Modules[1] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = BusinessLogic.Modes.View, ModuleId = Modules[2].Id, Module = Modules[2] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = BusinessLogic.Modes.Admin, ModuleId = Modules[3].Id, Module = Modules[3] }
            };

            PermissionsList1 = new List<Permission>
            {
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = BusinessLogic.Modes.Admin, ModuleId = Modules[0].Id, Module = Modules[0]},
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = BusinessLogic.Modes.Admin, ModuleId = Modules[1].Id, Module = Modules[1] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = BusinessLogic.Modes.Admin, ModuleId = Modules[2].Id, Module = Modules[2] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = BusinessLogic.Modes.Admin, ModuleId = Modules[3].Id, Module = Modules[3] }
            };
            Users = /*usersProvider.GetAllUsers();*/
            new List<User>
            {
                new User {FirstName="Дмитрий", LastName="Беломытцев", MiddleName="Сергеевич", Birthday=new DateTime(2005,3,31),
                    Gender=User.Genders.Man, IsBlocked=false, CreateDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permissions = PermissionsList, Photo = userPhoto},
                new User {FirstName="Мария", LastName="Искакова", MiddleName="Ринатовна", Birthday=new DateTime(2005,3,31),
                    Gender=User.Genders.Woman, IsBlocked=false, CreateDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permissions = PermissionsList1, Photo = userPhoto},
                new User {FirstName="Мария", LastName="Искакова", MiddleName="Ринатовна", Birthday=new DateTime(2000,3,31),
                    Gender=User.Genders.Woman, IsBlocked=false, CreateDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permissions = PermissionsList1, Photo = userPhoto}
            };


        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      

                  }));
            }
        }

        public List<User> UsersList
        {
            get { return usersProvider.GetAllUsers(); }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return addCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      usersProvider.DeleteUser(selectedUser);
                  }));
            }
        }

        //enable кнопки при изменении юзера
        private bool enabled = false;
        public bool Enabled
        {
            get
            {

                if (selectedUser != null)
                {
                    User user = selectedUser;
                    if (user.FirstName != selectedUser.FirstName)
                    {
                        enabled = true;
                    }
                }
                return enabled;
                
            }
        }
            
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      if (selectedUser != null)
                      {
                          OpenFileDialog openFileDialog = new OpenFileDialog();
                          openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                          openFileDialog.ShowDialog();
                          var path = openFileDialog.FileName;
                          if (path != "")
                          {
                              selectedUser.Photo = File.ReadAllBytes(path);
                          }
                          else
                          {
                              openFileDialog.Reset();
                          }
                      }

                  }));
            }
        }

        string _pattern;
        public string Pattern
        {
            get => _pattern;
            set
            {
                _pattern = value;
                SelectedUser = Users.FirstOrDefault(x => x.LastName.StartsWith(Pattern));
            }
        }
    }
}
