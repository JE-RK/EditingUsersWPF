using System;
using System.Collections.Generic;

namespace EditingUsersDAL;

public partial class Module
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
