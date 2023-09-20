using BusinessLogic;
using EditingUsersWPF.ViewModels.EnumBase;
using EditingUsersWPF.ViewModels.ViewModelEnumBase;
using EditingUsersDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.User;
using EditingUsersWPF.ViewModels.ViewModelEnumBase;
using User = BusinessLogic.User;
using System.Windows.Forms;
using System.IO;

namespace EditingUsersWPF
{
    public class UserViewModel : NotifyPropertyChangedBaseClass
    {
        public User user;
        private ObservableCollection<PermissionViewModel> permissionViewModel;
        private ObservableCollection<ModesViewModel<Modes>> modesEnum;
        public UserViewModel(User user, IEnumValuesProvider enumProvider) 
        { 
            this.user = user;
            permissionViewModel = new ObservableCollection<PermissionViewModel>(user.Permissions.Select(x =>
            new PermissionViewModel(x)));
            modesEnum = enumProvider.GetValues<Modes>().ToObservableCollection();
        }

        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      if (user != null)
                      {
                          OpenFileDialog openFileDialog = new OpenFileDialog();
                          openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                          openFileDialog.ShowDialog();
                          var path = openFileDialog.FileName;
                          if (path != "")
                          {
                              Photo = File.ReadAllBytes(path);
                          }
                          else
                          {
                              openFileDialog.Reset();
                          }
                      }

                  }));
            }
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
        public ObservableCollection<PermissionViewModel> PermissionsViewModel
        {
            get { return permissionViewModel; }
            set
            {
                permissionViewModel = value;
                OnPropertyChanged("PermissionsViewModel");
            }
        }

        public string LastName
        {
            get { return user.LastName; }
            set
            {
                user.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string FirstName
        {
            get { return user.FirstName; }
            set
            {
                user.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string MiddleName
        {
            get { return user.MiddleName; }
            set
            {
                user.MiddleName = value;
                OnPropertyChanged("MiddleName");
            }
        }
        public DateTime Birthday
        {
            get { return user.Birthday; }
            set
            {
                user.Birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public Genders Gender
        {
            get { return user.Gender; }
            set
            {
                if (user.Gender == value)
                    return;

                user.Gender = value;
                OnPropertyChanged("Gender");
                OnPropertyChanged("IsMan");
                OnPropertyChanged("IsWoman");
                OnPropertyChanged("TranslateGender");
            }
        }
        public bool IsMan
        {
            get { return Gender == Genders.Man; }
            set { Gender = value ? Genders.Man : Gender; }
        }

        public bool IsWoman
        {
            get { return Gender == Genders.Woman; }
            set { Gender = value ? Genders.Woman : Gender; }
        }

        public string TranslateGender
        {
            get { return user.Gender == Genders.Man ? "Мужчина" : "Женщина"; }
        }

        public DateTime CreateDate
        {
            get { return user.CreateDate; }
            set
            {
                user.CreateDate = value;
                OnPropertyChanged("CreateDate");
            }
        }

        public byte[] Photo
        {
            get { return user.Photo; }
            set
            {
                user.Photo = value;
                OnPropertyChanged("Photo");
            }
        }

        public DateTime ModifiedDate
        {
            get { return user.ModifiedDate; }
            set
            {
                user.ModifiedDate = value;
                OnPropertyChanged("ModifiedDate");
            }
        }

        public bool IsBlocked
        {
            get { return user.IsBlocked; }
            set
            {
                user.IsBlocked = value;
                OnPropertyChanged("IsBlocked");
                OnPropertyChanged("TranslateIsBlocked");
            }
        }
        public string TranslateIsBlocked
        {
            get { return user.IsBlocked ? "Заблокирован" : "Активен"; }
        }

    }
}
