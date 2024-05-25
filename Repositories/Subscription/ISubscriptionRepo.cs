namespace Repositories;

public interface ISubscriptionRepo
{
    Task CreateSubscription(int userId, int planId);
}