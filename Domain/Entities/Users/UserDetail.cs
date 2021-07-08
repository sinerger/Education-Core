using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Users
{
    public class UserDetail:UserAbstract
    {
        public Feedback Feedback { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
