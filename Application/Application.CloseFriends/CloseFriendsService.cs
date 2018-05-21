using System;
using RepositoriesServices.CloseFriends;
using Entities.CloseFriends;
using System.Collections.Generic;
using System.Linq;
using ApplicationServices.CalcLog;

namespace Application.CloseFriends
{
    public class CloseFriendsService : ApplicationServices.CloseFriends.ICloseFriendsService
    {
        ICloseFriendRepository _closeFriendRepository;
        ICalcLogService _calcLogService;

        public CloseFriendsService(ICloseFriendRepository closeFriendRepository, ICalcLogService calcLogService)
        {
            _closeFriendRepository = closeFriendRepository;
            _calcLogService = calcLogService;
        }

        public object[] GetFriends(int x, int y)
        {
            Position myPosition = new Position(x, y);

            var friendsPositions = _closeFriendRepository.GetPositions();

            var closeFriends = CalculeDistance(myPosition, friendsPositions);

            return closeFriends?.ToArray();
        }

        private List<Friend> CalculeDistance(Position selfPosition, List<Friend> friendsPositions)
        {
            foreach (var item in friendsPositions)
            {
                item.Distance = Math.Sqrt(Math.Pow(item.Position.X - selfPosition.X, 2) + Math.Pow(item.Position.Y - selfPosition.Y, 2));

                System.Threading.Tasks.Task.Run(() =>
                {
                    _calcLogService.Log(DateTime.Now, selfPosition.X, selfPosition.Y, item.Position.X, item.Position.Y, item.Distance);
                });
            }

            var topCloseFriends = (from d in friendsPositions
                                   orderby d.Distance ascending
                                   select d).Take(3);

            return topCloseFriends?.ToList();
        }
    }
}
