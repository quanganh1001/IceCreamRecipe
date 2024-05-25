
using Exceptions;
using IceCreamRecipe.Models;
using Microsoft.EntityFrameworkCore;
using Models.Plans;

namespace Repositories.Plans {
    public class PlanRepo : IPlanRepo {

        private readonly AppDbContext context;

        public PlanRepo(AppDbContext context) {
            this.context = context;
        }

        public async Task<List<Plan>> FindAll() {
            return await context.Plans.ToListAsync();
        }

        public async Task<Plan> FindById(int id) {
            return await context.Plans.FirstOrDefaultAsync(p => p.Id == id) ?? throw new NotFoundException("Plan not found");
        }
    }
}
