using BusinessLogic;
using Catel.Collections;
using EditingUsersWPF.ViewModels.EnumBase;
using EditingUsersWPF.ViewModels.ViewModelEnumBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EditingUsersWPF
{
    /// <summary>
    /// Логика взаимодействия для UserPermission.xaml
    /// </summary>
    public partial class UserPermission
    {

        public UserPermission(ObservableCollection<PermissionViewModel> permissionlist)
        {
            InitializeComponent();
            DataContext = permissionlist;
        }
    }
}
