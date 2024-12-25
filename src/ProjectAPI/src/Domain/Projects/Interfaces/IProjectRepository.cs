﻿using Als.Foundation.Data.Abstractions.EntityFramework;
using ProjectAPI.Domain.Projects.Entities;

namespace ProjectAPI.Domain.Projects.Interfaces;

public interface IProjectRepository : IBaseRepository<Project>
{
}
