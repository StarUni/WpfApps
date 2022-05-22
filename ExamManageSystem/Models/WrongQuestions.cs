namespace ExamManageSystem.Models
{
    using System;
    
    public partial class WrongQuestions
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public string QuestionType { get; set; }
        public int? QuestionScore { get; set; }
        public string GenerateTime { get; set; }
    }
}
