using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Model
{
    public class User
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string LoginName { get; set; }

        public string Password { get; set; }
    }
}
