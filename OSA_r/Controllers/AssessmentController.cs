namespace OSA_r.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly IAssesmentService _assesmentService;
        public AssessmentController(IAssesmentService assesmentService)
        {
            _assesmentService = assesmentService;
        }
        [Authorize(Policy = "Student")]
        [HttpGet]
        public IActionResult Index(int id)
        {
            var availableExams = _assesmentService.GetAvailableExams(id);
            return View(availableExams);
        }

        [Authorize(Policy = "Student")]
        [HttpGet]
        public IActionResult TakeExam(int examId, int questionIndex = 0)
        {
            var exam = _assesmentService.GetExamById(examId);

            if (exam == null || questionIndex >= exam.ExamQuestions.Count)
            {
                return NotFound();
            }

            var question = exam.ExamQuestions.ElementAt(questionIndex).Question;

            var model = new TakeExamViewModel
            {
                ExamId = examId,
                QuestionId = question.QuestionId,
                QuestionText = question.QuestionText,
                Options = new[] { "a", "b", "c", "d" }, 
                QuestionIndex = questionIndex,
                TotalQuestions = exam.ExamQuestions.Count
            };

            HttpContext.Items["ExamMode"] = true;
            return View(model);
        }

        [Authorize(Policy = "Student")]
        [HttpPost]
        public IActionResult SubmitAnswer(TakeExamViewModel model)
        {
            _assesmentService.SaveAnswer(model.StudentId, model.QuestionId, model.SelectedOption);

            if (model.QuestionIndex + 1 < model.TotalQuestions)
            {
                return RedirectToAction(nameof(TakeExam), new { examId = model.ExamId, questionIndex = model.QuestionIndex + 1 });
            }
            else
            {
                return RedirectToAction(nameof(SubmitExam), new { examId = model.ExamId, studentId = model.StudentId });
            }
        }

        // GET: /Exam/SubmitExam/{examId}
        [Authorize(Policy = "Student")]
        [HttpGet]
        public IActionResult SubmitExam(int examId, int studentId)
        {
            _assesmentService.SubmitExam(studentId, examId);

            var examResult = _assesmentService.GetExamResult(studentId, examId);
                 
            return View(examResult);
        }
    }
}
