namespace OSA_r.Services
{
    public class ExamQuestionsService : IExamQuestionsService
    {
        private readonly ApplicationDbContext _context;

        public ExamQuestionsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ExamQuestions> GetAll(int ExamId)
        {
            var examQuestions = _context.ExamQuestions.Where(eq => eq.ExamId == ExamId).ToList();
            return examQuestions;
        }

        public async Task Create(int QuestionId, int ExamId)
        {
            ExamQuestions examQuestion = new()
            {
                QuestionId = QuestionId,
                ExamId = ExamId
            };

            _context.Add(examQuestion);
            _context.SaveChanges();
        }

        public bool Delete(int QuestionId, int ExamId)
        {
            var isDeleted = false;

            var examQuestion = _context.ExamQuestions
                .SingleOrDefault(q => q.QuestionId == QuestionId && q.ExamId == ExamId);

            if (examQuestion is null)
                return isDeleted;

            _context.Remove(examQuestion);
            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;
            }

            return isDeleted;
        }
    }
}
