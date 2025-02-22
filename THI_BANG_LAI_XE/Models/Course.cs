using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public long TeacherId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual User Teacher { get; set; } = null!;

    public virtual ICollection<ExamPaper> ExamPapers { get; set; } = new List<ExamPaper>();
}
