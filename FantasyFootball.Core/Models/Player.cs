using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyFootball.Core.Models
{
    public class Player
    {
        public string Name { get; set; }
        public uint Goals { get; set; }
        public uint YellowCards { get; set; }
        public uint RedCards { get; set; }
        public int Value => 10 * (int)Goals + -2 * (int)YellowCards + -5 * (int)RedCards;
    }
}
