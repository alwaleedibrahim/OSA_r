namespace OSA_r.ViewModels.Question
{
    public class ViewQuestionsViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Subject { get; set; }
        public int InstructorId { get; set; }
        public string CorrectAnswer { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
    }
}
