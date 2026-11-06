using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    public class Nain : Heros
    {
        public Nain(int x, int y) : base(x, y)
        {
        }

        public override string Nom
        {
            get { return "Nain"; }
        }

        // le nain a +2 en endurance, donc plus de PV
        public override int Endurance
        {
            get { return base.Endurance + 2; }
        }
    }
}
