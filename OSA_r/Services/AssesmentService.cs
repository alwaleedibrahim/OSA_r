namespace OSA_r.Services
{
    public class AssesmentService : IAssesmentService
    {
        private readonly ApplicationDbContext _context;

        public AssesmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Exams> GetAvailableExams(int studentId)
        {
            var takenExamIds = _context.ExamResults
                .Where(er => er.StudentId == studentId)
                .Select(er => er.ExamId)
                .ToList();

            var availableExams = _context.Exams
                .Where(exam => !takenExamIds.Contains(exam.ExamId))
                .ToList();

            return availableExams;
        }

        public Exams GetExamById(int examId)
        {
            return _context.Exams
                .Include(e => e.ExamQuestions)
                .ThenInclude(eq => eq.Question)
                .FirstOrDefault(e => e.ExamId == examId);
        }

        public Questions GetQuestionById(int questionId)
        {
            return _context.Questions.FirstOrDefault(q => q.QuestionId == questionId);
        }

        public void SaveAnswer(int studentId, int questionId, string answerText)
        {
            var existingAnswer = _context.Answers
                .FirstOrDefault(a => a.StudentId == studentId && a.QuestionId == questionId);

            if (existingAnswer != null)
            {
                existingAnswer.AnswerText = answerText;
                _context.Answers.Update(existingAnswer);
            }
            else
            {
                var newAnswer = new Answers
                {
                    StudentId = studentId,
                    QuestionId = questionId,
                    AnswerText = answerText
                };
                _context.Answers.Add(newAnswer);
            }
            _context.SaveChanges();
        }


        public decimal CalculateScore(int studentId, int examId)
        {
            var answers = _context.Answers
                .Where(a => a.StudentId == studentId)
                .ToList();

            var examQuestions = _context.ExamQuestions
                .Where(eq => eq.ExamId == examId)
                .Include(eq => eq.Question)
                .ToList();

            int correctAnswersCount = 0;
            foreach (var eq in examQuestions)
            {
                var studentAnswer = answers.FirstOrDefault(a => a.QuestionId == eq.QuestionId);
                if (studentAnswer != null && studentAnswer.AnswerText == eq.Question.CorrectAnswer)
                {
                    correctAnswersCount++;
                }
            }
            var score = (decimal)correctAnswersCount / examQuestions.Count * 100;
            score = Math.Round(score, 2);
            return score;
        }

        public void SubmitExam(int studentId, int examId)
        {
            var score = CalculateScore(studentId, examId);

            var examResult = new ExamResults
            {
                ExamId = examId,
                StudentId = studentId,
                Score = score,
                CompletionTime = DateTime.UtcNow
            };

            _context.ExamResults.Add(examResult);
            _context.SaveChanges();
        }
        public ExamResults GetExamResult(int studentId, int examId)
        {
            return _context.ExamResults
                .Where(er => er.StudentId == studentId && er.ExamId == examId)
                .OrderBy(er => er.CompletionTime)
                .LastOrDefault();
        }
    }
}
