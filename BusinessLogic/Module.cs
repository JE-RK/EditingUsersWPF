using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
 
    public class Module
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
