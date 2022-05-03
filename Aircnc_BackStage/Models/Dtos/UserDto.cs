using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Models.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public string Photo { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public DateTime CreateTime { get; set; }
        public int? UserVerificationId { get; set; }
        public int? BankVerificationId { get; set; }
        public bool? IsDelete { get; set; }
        public bool? MailIsVerify { get; set; }

    }
}
