using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Homeworks;

namespace Domain.Entities.Solutions
{
    public class Solution
    {
        public Guid ID { get; set; }
        public string Answer { get; set; }
        public int Mark { get; set; }
        public Homework Homework { get; set; }
    }
}
