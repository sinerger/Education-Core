using System;
using System.Collections.Generic;
using Domain.Entities.Feedbacks;

namespace Domain.Entities.Users
{
    public class UserDetail : UserAbstract
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
