using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class UserSelectedAnswer
{
    public long SelectedId { get; set; }

    public long? UserId { get; set; }

    public long QuestionId { get; set; }

    public long AnswerId { get; set; }

    public int ExamId { get; set; }

    public virtual Answer Answer { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual User? User { get; set; }
}
