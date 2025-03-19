﻿using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public int CourseId { get; set; }

    public DateOnly Date { get; set; }

    public string Room { get; set; } = null!;

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual ICollection<ExamPaper> ExamPapers { get; set; } = new List<ExamPaper>();
}
