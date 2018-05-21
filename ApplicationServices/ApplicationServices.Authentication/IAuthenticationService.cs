using CrossCutting.Authentication;
using System;

namespace ApplicationServices.Authentication
{
    public interface IAuthenticationService
    {
        object Login(User user);
    }
}
