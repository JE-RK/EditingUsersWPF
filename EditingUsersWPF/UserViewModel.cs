﻿using BusinessLogic;
using BusinessLogic.EnumBase;
using BusinessLogic.ViewModelEnumBase;
using EditingUsersDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.User;

namespace EditingUsersWPF
{
    public class UserViewModel : NotifyPropertyChangedBaseClass
    {
        private User user;
        private ObservableCollection<PermissionViewModel> permissionViewModel;
        public UserViewModel(User user) 
        { 
            this.user = user;
            permissionViewModel = new ObservableCollection<PermissionViewModel>(user.Permissions.Select(x => 
            new PermissionViewModel(x, new EnumValuesProvider(new EnumDescriptionProvider()))));
        }

        public ObservableCollection<PermissionViewModel> PermissionsViewModel
        {
            get { return permissionViewModel; }
            set
            {
                permissionViewModel = value;
                OnPropertyChanged("Permissions");
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
