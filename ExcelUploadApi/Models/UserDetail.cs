using System;
using System.Collections.Generic;

namespace ExcelUploadApi.Models
{
    public partial class UserDetail
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? EmailId { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? MobileNo { get; set; }
        public string? PinCode { get; set; }
    }
}
