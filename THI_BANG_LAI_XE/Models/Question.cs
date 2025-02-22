using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class Question
{
    public long QuestionId { get; set; }

    public int ExamPaperId { get; set; }

    public string DetailQuestion { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ExamPaper ExamPaper { get; set; } = null!;
}
