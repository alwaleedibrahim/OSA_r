namespace OSA_r.Services
{
    public interface IAssesmentService
    {
        IEnumerable<Exams> GetAvailableExams(int StudentId);
        Exams GetExamById(int examId);
        Questions GetQuestionById(int questionId);
        void SaveAnswer(int studentId, int questionId, string answerText);
        void SubmitExam(int studentId, int examId);
        ExamResults GetExamResult(int studentId, int examId);
    }
}
