namespace OSA_r.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly ApplicationDbContext _context;

        public QuestionsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Questions> GetAll()
        {
            return _context.Questions
                .ToList();
        }

        public IEnumerable<Questions> GetAll(int InstructorId)
        {
            var questions = _context.Questions.Where(q => q.InstructorId == InstructorId).ToList();
            return questions;
        }

        public Questions? GetById(int id)
        {
            return _context.Questions
                .SingleOrDefault(u => u.QuestionId == id);
        }

        public async Task Create(CreateQuestionFormViewModel model)
        {
            Questions question = new()
            {
                QuestionText = model.QuestionText,
                Category = model.Category,
                Subject = model.Subject,
                InstructorId = model.InstructorId,
                CorrectAnswer = model.CorrectAnswer,
                Topic = model.Topic,
                Level = model.Level,
            };

            _context.Add(question);
            _context.SaveChanges();
        }

        public async Task<Questions?> Update(EditQuestionFormViewModel model)
        {
            var question = _context.Questions
                .SingleOrDefault(u => u.QuestionId == model.QuestionId);

            if (question is null)
                return null;


            question.QuestionText = model.QuestionText;
            question.Subject = model.Subject;
            question.InstructorId = model.InstructorId;
            question.CorrectAnswer = model.CorrectAnswer;
            question.Topic = model.Topic;
            question.Level = model.Level;
            question.Category = model.Category;

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                return question;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(DeleteQuestionFormViewModel model)
        {
            var isDeleted = false;

            var question = _context.Questions
                .SingleOrDefault(u => u.QuestionId == model.QuestionId);

            if (question is null)
                return isDeleted;

            _context.Remove(question);
            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;
            }

            return isDeleted;
        }

    }
}
