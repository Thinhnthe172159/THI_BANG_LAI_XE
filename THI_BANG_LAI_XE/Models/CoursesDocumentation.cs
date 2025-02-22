using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using System.ComponentModel.DataAnnotations.Schema;

namespace THI_BANG_LAI_XE.Models
{
    [PrimaryKey(nameof(CourseId), nameof(ExamPaperId))]

    public class CoursesDocumentation
    {
        [Key, Column(Order = 0)]
        public int CourseId { get; set; }
        [Key, Column(Order = 1)]
        public int ExamPaperId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course? Course { get; set; }
        [ForeignKey(nameof(ExamPaperId))]
        public virtual ExamPaper? ExamPaper { get; set; }
    }
}
