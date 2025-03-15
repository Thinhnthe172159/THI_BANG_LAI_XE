using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class UserSelectedAnswer
{
    public long UserId { get; set; }

    public long QuestionId { get; set; }

    public long? AnswerId { get; set; }

    public virtual Answer? Answer { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
