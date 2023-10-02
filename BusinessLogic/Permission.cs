using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.Modes;

namespace BusinessLogic
{
    public class Permission
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Modes Mode { get; set; }
        public Guid ModuleId { get; set; }
        public User User { get; set; }
        //public Module Module { get; set; }
    }
}

