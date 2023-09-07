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
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Modes Mode { get; set; }
        public Guid ModuleId { get; set; }
        public Modules Module { get; set; }



        private Modules module;
        private Modes editmode;



        
        
    }
}

