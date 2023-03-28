﻿using DataAccess.Entities;

namespace aspnetcore.ntier.DAL.Repositories.IRepositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> UpdateUser(User user);
}
