namespace OSA_r.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionsService _questionsService;

        public QuestionController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Index()
        {
            var questions = _questionsService.GetAll();
            return View(questions);
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Create()
        {
            CreateQuestionFormViewModel viewModel = new();

            return View(viewModel);
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var question = _questionsService.GetById(id);

            if (question is null)
                return NotFound();

            EditQuestionFormViewModel viewModel = new()
            {
                QuestionId = question.QuestionId,
                QuestionText = question.QuestionText,
                Category = question.Category,
                Subject = question.Subject,
                InstructorId = question.InstructorId,
                CorrectAnswer = question.CorrectAnswer,
                Topic = question.Topic,
            };

            return View(viewModel);
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var question = _questionsService.GetById(id);

            if (question is null)
                return NotFound();

            return View(question);
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var question = _questionsService.GetById(id);

            if (question is null)
                return NotFound();

            DeleteQuestionFormViewModel viewModel = new()
            {
                QuestionId = question.QuestionId,
                QuestionText = question.QuestionText
            };

            return View(viewModel);
        }

        [Authorize(Policy = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _questionsService.Create(model);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> Update(EditQuestionFormViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            var question = await _questionsService.Update(model);

            if (question is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Instructor")]
        [HttpPost]
        public IActionResult Delete(DeleteQuestionFormViewModel model)
        {
            var isDeleted = _questionsService.Delete(model);

            if (isDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest("Failed to delete the question.");
            }
        }

    }
}
