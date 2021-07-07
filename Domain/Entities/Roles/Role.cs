using Insight.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Roles
{
    public class Role
    {
        public Guid ID { get; set; }

        public TypeRole Type { get; private set; }
    }
}
