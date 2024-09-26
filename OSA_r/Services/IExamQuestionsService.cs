namespace OSA_r.Services
{
    public interface IExamQuestionsService
    {
        IEnumerable<ExamQuestions> GetAll(int ExamId);
        Task Create(int QuestionId, int ExamId);
        bool Delete(int QuestionId, int ExamId);
    }
}
