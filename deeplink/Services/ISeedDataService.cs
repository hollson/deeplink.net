using Deeplink.Repositories;
using System.Threading.Tasks;

namespace Deeplink.Services
{
    public interface ISeedDataService
    {
        Task Initialize(FoodDbContext context);
    }
}
