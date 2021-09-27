using System;
using System.Collections.Generic;

namespace Schlagenfun.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public List<Team> Teams { get; set; }
    }
}
