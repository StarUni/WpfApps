namespace ExamManageSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleInfo
    {
        public int Id { get; set; }
        public string RoleDescribe { get; set; }
        public string Privilege { get; set; }
        public string RoleSC { get; set; }
    }
}
