using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class Result
{
    public long ResultId { get; set; }

    public int ExamId { get; set; }

    public long UserId { get; set; }

    public decimal Score { get; set; }

    public int PassStatus { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public int ExamPaperId { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
