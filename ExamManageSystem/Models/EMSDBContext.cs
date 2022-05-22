using ExamManageSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public partial class EMSDBContext : DbContext
    {
        public virtual DbSet<DataDictionary> DataDictionary { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<RoleInfo> RoleInfo { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<WrongQuestions> WrongQuestions { get; set; }

        public EMSDBContext(DbContextOptions<EMSDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=D:\Workspace\ExamManageSystem\Localdb\exam.db");
        }
    }
}