using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class User
{
    public long UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public string? Class { get; set; }

    public string? School { get; set; }

    public string? Phone { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual Role RoleNavigation { get; set; } = null!;

    public virtual ICollection<UserSelectedAnswer> UserSelectedAnswers { get; set; } = new List<UserSelectedAnswer>();
}
