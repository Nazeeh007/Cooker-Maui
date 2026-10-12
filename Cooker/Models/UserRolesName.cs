using System;
using System.Collections.Generic;

namespace Cooker.Models;

public partial class UserRolesName
{
    public int? RoleId { get; set; }

    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? RoleName { get; set; }
}
