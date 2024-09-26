namespace OSA_r.ViewModels.Exam
{
    public class DeleteExamFormViewModel
    {
        public int ExamId { get; set; }
        public int InstructorId { get; set; }
        public string ExamName { get; set; } = string.Empty;
        public DateTime ExamDate { get; set; } = DateTime.Now;
    }
}
