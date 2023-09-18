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

namespace EditingUsersWPF
{
    public class ApplicationViewModel : NotifyPropertyChangedBaseClass
    {
        private UserViewModel selectedUser;
        private byte[] userPhoto;
        public List<UserViewModel> Users { get; set; }
        public List<Modules> Modules;
        public ObservableCollection<Permission> PermissionsList { get; set; }
        public ObservableCollection<UserViewModel> UserViewModelList { get; set; }

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
            userPhoto = File.ReadAllBytes(@"C:\Users\d-bel\Downloads\kinozpis.jpg");
            Modules = new List<Modules>
            {
                new Modules {Id = Guid.NewGuid(), Name="Продажи"},
                new Modules {Id = Guid.NewGuid(), Name="Закупки"},
                new Modules {Id = Guid.NewGuid(), Name="Аналитика"},
                new Modules {Id = Guid.NewGuid(), Name="Администрирование"},
            };

            PermissionsList = new ObservableCollection<Permission>
            {
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Mode = BusinessLogic.Modes.Admin, ModuleId = Modules[0].Id, Module = Modules[0]},
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Mode = BusinessLogic.Modes.Edit, ModuleId = Modules[1].Id, Module = Modules[1] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Mode = BusinessLogic.Modes.View, ModuleId = Modules[2].Id, Module = Modules[2] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Mode = BusinessLogic.Modes.Admin, ModuleId = Modules[3].Id, Module = Modules[3] }
            };


            User user = new User
            {
                FirstName = "Дмитрий",
                LastName = "Беломытцев",
                MiddleName = "Сергеевич",
                Birthday = new DateTime(2005, 3, 31),
                Gender = User.Genders.Man,
                IsBlocked = false,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Permissions = PermissionsList,
                Photo = userPhoto
            };
            UserViewModelList = new ObservableCollection<UserViewModel>
            {
                new UserViewModel(user, new EnumValuesProvider(new EnumDescriptionProvider()))
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
