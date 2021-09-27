using System;
using System.Collections.Generic;

namespace Schlagenfun.Domain
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public Team()
        {
            this.Name = String.Empty;
            this.Players = new List<Player>();
        }

    }
}
