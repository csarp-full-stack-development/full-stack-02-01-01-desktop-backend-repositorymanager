﻿using Kreta.Backend.Context;
using Kreta.Backend.Repos;
using Kreta.Backend.Repos.KretaInMemoryRepo;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Extensions
{
    public static class KretaBackendExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "KretaCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7020/")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                 )
            );
        }

        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbName = "Kreta" + Guid.NewGuid();
            services.AddDbContext<KretaContext>(
                  options => options.UseInMemoryDatabase(databaseName: dbName)
            );
            services.AddDbContext<KretaInMemoryContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
            );
        }

        public static void ConfigureRepoService(this IServiceCollection services)
        {
            services.AddScoped<ITeacherRepo, TeacherRepo<KretaInMemoryContext>>();
            services.AddScoped<IGradeRepo, GradeRepo<KretaInMemoryContext>>();
            services.AddScoped<IParentRepo, ParentRepo<KretaInMemoryContext>>();
            services.AddScoped<IStudentRepo, StudentRepo<KretaInMemoryContext>>();
            services.AddScoped<ISubjectRepo, SubjectRepo<KretaInMemoryContext>>();
            services.AddScoped<IEducationLevelRepo, EducationLevelRepo<KretaInMemoryContext>>();
            services.AddScoped<ISchoolClassRepo, SchoolClassRepo<KretaInMemoryContext>>();
            services.AddScoped<IAddressRepo, AddressRepo<KretaInMemoryContext>>();
            services.AddScoped<IPublicSpaceRepo, PublicSpaceRepo<KretaInMemoryContext>>();
            services.AddScoped<ITypeOfEducationRepo, TypeOfEducationRepo<KretaInMemoryContext>>();
        }

        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<TeacherAssambler>();
            services.AddScoped<GradeAssambler>();
            services.AddScoped<ParentAssambler>();
            services.AddScoped<StudentAssambler>();
            services.AddScoped<SubjectAssambler>();
            services.AddScoped<TypeOfEducationAssambler>();
            services.AddScoped<EducationLevelAssambler>();
            services.AddScoped<SchoolClassAssambler>();
            services.AddScoped<AddressAssambler>();
            services.AddScoped<PublicSpaceAssambler>();
            services.AddScoped<SchoolClassAssambler>();
            services.AddScoped<TypeOfEducationAssambler>();
        }
    }
}
