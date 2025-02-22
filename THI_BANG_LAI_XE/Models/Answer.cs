using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class Answer
{
    public long AnswerId { get; set; }

    public long QuestionId { get; set; }

    public string DetailAnswer { get; set; } = null!;

    public int IsCorrectOrNot { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<UserSelectedAnswer> UserSelectedAnswers { get; set; } = new List<UserSelectedAnswer>();
}
