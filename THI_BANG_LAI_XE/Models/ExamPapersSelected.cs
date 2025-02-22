using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace THI_BANG_LAI_XE.Models
{
    [PrimaryKey(nameof(ExamId), nameof(ExamPaperId))]
    public class ExamPapersSelected
    {
        public int ExamId { get; set; }
        public int ExamPaperId { get; set; }
        [ForeignKey(nameof(ExamId))]
        public virtual Exam? Exam { get; set; }
        [ForeignKey(nameof(ExamPaperId))]
        public virtual ExamPaper? ExamPaper { get; set; }
    }
}
