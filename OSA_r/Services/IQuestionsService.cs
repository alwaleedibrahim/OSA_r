namespace OSA_r.Services
{
    public interface IQuestionsService
    {
        IEnumerable<Questions> GetAll();
        public IEnumerable<Questions> GetAll(int InstructorId);
        Questions? GetById(int id);
        Task Create(CreateQuestionFormViewModel model);
        Task<Questions?> Update(EditQuestionFormViewModel model);
        bool Delete(DeleteQuestionFormViewModel model);
    }
}