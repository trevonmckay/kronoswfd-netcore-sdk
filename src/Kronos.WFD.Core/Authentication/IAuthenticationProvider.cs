using System.Net.Http;
using System.Threading.Tasks;

namespace Kronos.WFD.Authentication
{
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Authenticates the specified request message.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to authenticate.</param>
        /// <returns>The task to await.</returns>
        Task AuthenticateRequestAsync(HttpRequestMessage request);
    }
}
