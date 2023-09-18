using System;
using System.Collections.Generic;

namespace EditingUsersDAL;

public partial class User
{
    public Guid Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public int Gender { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public bool IsBlocked { get; set; }

    public byte[] Photo { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
