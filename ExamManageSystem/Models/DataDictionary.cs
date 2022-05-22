namespace ExamManageSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataDictionary
    {
        public int Id { get; set; }
        public string DataType { get; set; }
        public string ShortCode { get; set; }
        public string FullCode { get; set; }
        public string DataName { get; set; }
        public string CreateTime { get; set; }
    }
}
