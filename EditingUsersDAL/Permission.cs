using System;
using System.Collections.Generic;

namespace EditingUsersDAL;

public partial class Permission
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int Mode { get; set; }

    public Guid ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
