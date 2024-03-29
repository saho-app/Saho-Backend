﻿using System;
using System.Collections.Generic;

namespace Entities;

public partial class RoleEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
}
