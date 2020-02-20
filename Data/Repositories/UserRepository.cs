﻿using Api.Core.Model.Entities;
using Api.Core.Model.Repositories;
using Api.Data.DataAccess;

namespace Api.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

    }
}