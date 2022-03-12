using PracticeAPI.Data.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAPI.Data
{
    public interface IPracticeAPIDataService
    {
        IUserRepo UserRepo { get; }
    }
}
