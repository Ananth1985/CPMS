﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Data.Repositories
{
    public interface ILoginRepository
    {
        public string GetLoginDetails(string email, string password);
    }
}
