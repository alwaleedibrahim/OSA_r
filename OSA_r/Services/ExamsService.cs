namespace OSA_r.Services
{
    public class ExamsService : IExamsService
    {
        private readonly ApplicationDbContext _context;

        public ExamsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Exams> GetAll()
        {
            return _context.Exams
                .ToList();
        }

        public Exams? GetById(int id)
        {
            return _context.Exams
                .SingleOrDefault(u => u.ExamId == id);
        }

        public async Task Create(CreateExamFormViewModel model)
        {
            Exams exam = new()
            {
                ExamName = model.ExamName,
                InstructorId = model.InstructorId,
                ExamDate = model.ExamDate
            };

            _context.Add(exam);
            _context.SaveChanges();
        }

        public async Task<Exams?> Update(EditExamFormViewModel model)
        {
            var exam = _context.Exams
                .SingleOrDefault(u => u.ExamId == model.ExamId);

            if (exam is null)
                return null;


            exam.ExamName = model.ExamName;
            exam.InstructorId = model.InstructorId;
            exam.ExamDate = model.ExamDate;

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                return exam;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(DeleteExamFormViewModel model)
        {
            var isDeleted = false;

            var exam = _context.Exams
                .SingleOrDefault(u => u.ExamId == model.ExamId);

            if (exam is null)
                return isDeleted;

            _context.Remove(exam);
            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;
            }

            return isDeleted;
        }

    }
}
