﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAPI.Data.Entities
{
    public class UserEntity
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}
