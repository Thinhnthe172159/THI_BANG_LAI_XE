using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class Registration
{
    public long RegistrationId { get; set; }

    public long UserId { get; set; }

    public int? CourseId { get; set; }

    public int? Status { get; set; }

    public string? Comments { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public virtual Course? Course { get; set; }

    public virtual User User { get; set; } = null!;
}
