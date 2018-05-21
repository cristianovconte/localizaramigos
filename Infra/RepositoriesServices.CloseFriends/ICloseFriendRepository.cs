using System.Collections.Generic;
using Entities.CloseFriends;

namespace RepositoriesServices.CloseFriends
{
    public interface ICloseFriendRepository
    {
        List<Friend> GetPositions();
    }
}
