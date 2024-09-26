namespace OSA_r.ViewModels.Assessment
{
    public class TakeExamViewModel
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string[] Options { get; set; }
        public int QuestionIndex { get; set; }
        public int TotalQuestions { get; set; }
        public string SelectedOption { get; set; }
        public int StudentId { get; set; }
    }

}
