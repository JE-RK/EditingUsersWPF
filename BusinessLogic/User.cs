using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class User : NotifyPropertyChangedBaseClass
    {
        [Key]
        public Guid Id { get; set; }
        private string lastname;
        private string firstname;
        private string middlename;
        private DateTime birthday;
        private Genders gender;
        private DateTime createDate;
        private byte[] photo;
        private DateTime modifiedDate;
        private bool isBlocked;
        private List<Permission> permissions;
        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string MiddleName
        {
            get { return middlename; }
            set
            {
                middlename = value;
                OnPropertyChanged("MiddleName");
            }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public Genders Gender
        {
            get { return gender; }
            set
            {
                if (gender == value)
                    return;

                gender = value;
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
            get { return gender == Genders.Man ? "Мужчина" : "Женщина"; }
        }

        public DateTime CreateDate
        {
            get { return createDate; }
            set
            {
                createDate = value;
                OnPropertyChanged("CreateDate");
            }
        }

        public  byte[] Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                OnPropertyChanged("Photo");
            }
        }

        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set
            {
                modifiedDate = value;
                OnPropertyChanged("ModifiedDate");
            }
        }

        public bool IsBlocked
        {
            get { return isBlocked; }
            set
            {
                isBlocked = value;
                OnPropertyChanged("IsBlocked");
                OnPropertyChanged("TranslateIsBlocked");
            }
        }
        public string TranslateIsBlocked
        {
            get { return isBlocked ? "Заблокирован" : "Активен"; }
        }
        public List<Permission>  Permissions
        {
            get { return permissions; }
            set
            {
                permissions = value;
                OnPropertyChanged("Permissions");
            }
        }

        public enum Genders
        { 
            Man,
            Woman
        }

    }
}
