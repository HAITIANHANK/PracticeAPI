using PracticeAPI.Data.Repos.Contracts;
using PracticeAPI.Data.Repos.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAPI.Data
{
    public class PracticeAPIDataService : BaseDataService, IPracticeAPIDataService
    {
        private IUserRepo _userRepo;
        public PracticeAPIDataService(string connStr) : base(connStr)
        {
        }
        public IUserRepo UserRepo { get => _userRepo ??= new UserRepo(this); }

    }
}
