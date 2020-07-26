using System.Threading;
using System.Threading.Tasks;
using BmesRestApi.Messages.Requests.Users;
using BmesRestApi.Messages.Responses.Users;

namespace BmesRestApi.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
        Task<LogInResponse> LogInAsync(LogInRequest request, CancellationToken cancellationToken = default);
    }
}
