using PracticeAPI.BusinessEntities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAPI.Data.Entities
{
    public class UserEntity
    {
        public string FirstName;
        public string LastName;
        public string FullName;
        
        public static implicit operator UserEntity(UserBE userBE)
        {
            return new UserEntity
            {
                FirstName = userBE.FirstName,
                LastName = userBE.LastName,
                FullName = userBE.FullName
            };
        }
    }
}
