using CrossCutting.Authentication;
using System;

namespace RepositoriesServices.Authentication
{
    public interface IAuthenticationRepository
    {
        User Login(User userId);
    }
}
