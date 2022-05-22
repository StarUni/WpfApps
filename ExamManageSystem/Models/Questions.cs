namespace ExamManageSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Questions
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? Score { get; set; }
        public string QuestionType { get; set; }
        public string Subject { get; set; }
        public string Options { get; set; }
        public string Answer { get; set; }
        public string CreateTime { get; set; }
        public string PaperName { get; set; }
    }
}
