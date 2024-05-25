using Models.Feedbacks;

namespace Repositories.Feedbacks {
    public interface IFeedbackRepo {

        Task Create(FeedbackCreateDto dto);

        Task<ICollection<Feedback>> FindAll();

        Task<Feedback> FindById(int id);

        Task<Feedback> FindByEmail(string email);

    }
}
