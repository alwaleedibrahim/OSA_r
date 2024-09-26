namespace OSA_r.Services
{
    public interface IExamsService
    {
        IEnumerable<Exams> GetAll();
        Exams? GetById(int id);
        Task Create(CreateExamFormViewModel model);
        Task<Exams?> Update(EditExamFormViewModel model);
        bool Delete(DeleteExamFormViewModel model);
    }
}