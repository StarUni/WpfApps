﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamManageSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CargoEntities1 : DbContext
    {
        public CargoEntities1()
            : base("name=CargoEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<CargoType> CargoType { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Record> Record { get; set; }
        public virtual DbSet<DataDictionary> DataDictionary { get; set; }
        public virtual DbSet<ExamPaper> ExamPaper { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<RoleInfo> RoleInfo { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<WrongQuestions> WrongQuestions { get; set; }
    }
}
