using BusinessLogic;
using BusinessLogic.ViewModelEnumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersWPF
{
    public class SelectedUserViewModel
    {
        private User selectedUser;
        public SelectedUserViewModel(IEnumValuesProvider enumProvider) 
        { 
            this.selectedUser = selectedUser;
        }
        public List<Permission> Get_Permissions()
        {
            return selectedUser.Permissions;
        }
        
        public List<Modules> list;
    }
}
