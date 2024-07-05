using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_Management.Models;

namespace School_Management.Data
{
    public class School_ManagementContext : DbContext
    {
        public School_ManagementContext (DbContextOptions<School_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<School_Management.Models.ExamModel> ExamModel { get; set; } = default!;
        public DbSet<School_Management.Models.SchoolLoginModel> SchoolLoginModel { get; set; } = default!;
        public DbSet<School_Management.Models.SchoolRegisterModel> SchoolRegisterModel { get; set; } = default!;
        public DbSet<School_Management.Models.StudentModel> StudentModel { get; set; } = default!;
        public DbSet<School_Management.Models.TeacherModel> TeacherModel { get; set; } = default!;
    }
}
