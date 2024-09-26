namespace OSA_r.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamsService _examsService;

        public ExamController(IExamsService examsService)
        {
            _examsService = examsService;
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Index()
        {
            var exams = _examsService.GetAll();
            return View(exams);
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Create()
        {
            CreateExamFormViewModel viewModel = new();

            return View(viewModel);
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var exam = _examsService.GetById(id);

            if (exam is null)
                return NotFound();

            EditExamFormViewModel viewModel = new()
            {
                ExamId = exam.ExamId,
                InstructorId = exam.InstructorId,
                ExamName = exam.ExamName,
                ExamDate = exam.ExamDate
            };

            return View(viewModel);
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var exam = _examsService.GetById(id);

            if (exam is null)
                return NotFound();

            return View(exam);
        }

        [Authorize(Policy = "Instructor")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var exam = _examsService.GetById(id);

            if (exam is null)
                return NotFound();

            DeleteExamFormViewModel viewModel = new()
            {
                ExamId = exam.ExamId,
                ExamName = exam.ExamName
            };

            return View(viewModel);
        }

        [Authorize(Policy = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateExamFormViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var exam = _examsService.Create(model);

            if (exam is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> Update(EditExamFormViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            var exam = await _examsService.Update(model);

            if (exam is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Instructor")]
        [HttpPost]
        public IActionResult Delete(DeleteExamFormViewModel model)
        {
            var isDeleted = _examsService.Delete(model);

            if (isDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest("Failed to delete the user.");
            }
        }

    }
}
