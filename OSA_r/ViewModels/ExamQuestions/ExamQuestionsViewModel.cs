namespace OSA_r.ViewModels.ExamQuestions
{
    public class ExamQuestionsViewModel
    {
        public IEnumerable<Models.ExamQuestions> ExamQuestions { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
        public int ExamId { get; set; }
        public int InstructorId { get; set; }

    }
}
