using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class ExamPaper
{
    public int ExamPaperId { get; set; }

    public string ExamPaperName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<UserSelectedAnswer> UserSelectedAnswers { get; set; } = new List<UserSelectedAnswer>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
