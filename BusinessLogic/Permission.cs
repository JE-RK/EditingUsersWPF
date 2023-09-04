using BusinessLogic.EnumBase;
using BusinessLogic.ViewModelEnumBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.Modes;

namespace BusinessLogic
{
    public class Permission : NotifyPropertyChangedBaseClass
    {
        private Modules module;
        private Modes editmode;
        private List<Modes> modes = new List<Modes>
        {
            Modes.Edit,
            Modes.View,
            Modes.Admin
        };

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Modes EditMode
        {
            get { return editmode; }
            set
            {
                editmode = value;
                OnPropertyChanged("EditMode");
            }
        }

        public List<Modes> GetModes { get { return modes; } }
        public Guid ModuleId { get; set; }
        public Modules Module
        {
            get { return module; }
            set
            {
                module = value;
                OnPropertyChanged("Module");
            }
        }
        
    }
}

