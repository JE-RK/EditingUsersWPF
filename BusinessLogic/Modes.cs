using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public enum Modes
    {
        [Description("Просматривать")]
        View,
        [Description("Редактировать")]
        Edit,
        [Description("Администратор")]
        Admin
    }
}
