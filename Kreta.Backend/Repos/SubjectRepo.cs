﻿using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class SubjectRepo<TDbContext> : RepositoryBase<TDbContext, Subject>, ISubjectRepo
        where TDbContext : DbContext
    {
        public SubjectRepo(TDbContext? dbContext) : base(dbContext)
        {

        }
    }
}
