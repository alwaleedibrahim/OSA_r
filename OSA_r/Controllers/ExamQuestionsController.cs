using Microsoft.AspNetCore.Http.Extensions;
using OSA_r.Models;
using OSA_r.ViewModels.ExamQuestions;

namespace OSA_r.Controllers
{
    public class ExamQuestionsController : Controller
    {
        private readonly IExamQuestionsService _examQuestionsService;
        private readonly IQuestionsService _questionsService;
        private readonly IExamsService _examsService;

        public ExamQuestionsController(IExamQuestionsService examQuestionsService,
            IExamsService examsService, IQuestionsService questionsService)
        {
            _examQuestionsService = examQuestionsService;
            _examsService = examsService;
            _questionsService = questionsService;
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult ShowExamQuestions(int ExamId, int InstructorId)
        {
            var examQuestions = _examQuestionsService.GetAll(ExamId);
            var questions = _questionsService.GetAll(InstructorId);

            var viewModel = new ExamQuestionsViewModel
            {
                ExamQuestions = examQuestions,
                Questions = questions,
                ExamId = ExamId,
                InstructorId = InstructorId
            };

            return View(viewModel);
        }


        [Authorize(Policy = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> AddQuestion(int QuestionId, int ExamId, int InstructorId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowExamQuestions), new { ExamId = ExamId, InstructorId = InstructorId });
            }
            var examQuestion = _examQuestionsService.Create(QuestionId, ExamId);

            if (examQuestion is null)
                return BadRequest();
            return RedirectToAction(nameof(ShowExamQuestions), new { ExamId = ExamId, InstructorId = InstructorId });
        }

        [Authorize(Policy = "Instructor")]
        [HttpPost]
        public IActionResult RemoveQuestion(int QuestionId, int ExamId, int InstructorId)
        {
            var isDeleted = _examQuestionsService.Delete(QuestionId, ExamId);

            if (isDeleted)
            {

                return RedirectToAction(nameof(ShowExamQuestions), new { ExamId = ExamId, InstructorId = InstructorId });
            }
            else
            {
                return BadRequest("Failed to remove the question.");
            }
        }
    }
}
