namespace Kreta.Backend.Repos.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private ISchoolClassRepo? _schooolClassRepo;       
        private ISubjectRepo? _subjectRepo;


        public RepositoryManager(
            ISchoolClassRepo schoolClassRepo,
            ISubjectRepo subjectRepo

            )
        {
            _schooolClassRepo = schoolClassRepo;
            _subjectRepo = subjectRepo;
        }

        public ISchoolClassRepo? SchoolClassRepo => _schooolClassRepo;
        public ISubjectRepo? SubjectRepo => _subjectRepo;
    }
}
