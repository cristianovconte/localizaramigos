using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.CloseFriends
{
    public class Friend : Person
    {
        public Position Position { get; set; }

        public double Distance { get; set; }

        public Friend(int id, string name, int X, int Y)
            : base(id, name)
        {
            Position = new Position(X, Y);
        }
    }
}
