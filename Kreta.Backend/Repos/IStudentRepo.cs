using Kreta.Shared.Models.SchoolCitizens;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public interface IStudentRepo : IRepositoryBase<Student>
    {
        public IQueryable<Student> SelectAllIncluded()
        {
            return FindAll().Include(student => student.EducationLevel);
        }

        public IQueryable<Student> SelectStudentsByEducationId(Guid educationID)
        {
            return FindAll().Where(student => student.EducationLevelId == educationID);
        }

        public IQueryable<Student> SelectStudentsWithoutEducationLevel()
        {
            return FindAll().Where(student =>
                student.EducationLevelId == null ||
                student.EducationLevelId == Guid.Empty);
        }
    }
}
