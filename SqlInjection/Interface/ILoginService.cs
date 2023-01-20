using Microsoft.Extensions.Configuration;
using SqlInjection.Models;

namespace SqlInjection.Interface
{
    public interface ILoginService
    {
        Usuario LoginComPrepared(IConfiguration config, Usuario usuario);
        Usuario LoginSemPrepared(IConfiguration config, Usuario usuario);
    }
}