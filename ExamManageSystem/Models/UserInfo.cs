namespace ExamManageSystem.Models
{
    using System;
    
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? RoleInfoId { get; set; }
        public string Password { get; set; }
        public string CreateTime { get; set; }
        public string Salt { get; set; }
    }
}
