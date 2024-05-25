
using Models.Plans;

namespace Repositories.Plans {
    public interface IPlanRepo {

        Task<Plan> FindById(int id);

        Task<List<Plan>> FindAll();

    }
}
