//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Questions
    {
        public int Id { get; set; }
        public int ExamPaperId { get; set; }
        public string Content { get; set; }
        public Nullable<int> Score { get; set; }
        public string QuestionType { get; set; }
        public string Subject { get; set; }
        public string Options { get; set; }
        public string Answer { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}