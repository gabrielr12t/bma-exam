using System.Threading.Tasks;

namespace Bma.Services.Installation
{
    public interface IInstallFakeDataService
    {
        Task InitializeDatabase();
    }
}