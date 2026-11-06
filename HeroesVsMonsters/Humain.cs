using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    public class Humain : Heros
    {
        public Humain(int x, int y) : base(x, y)
        {
        }

        public override string Nom
        {
            get { return "Humain"; }
        }

        // l'humain a +1 en force et +1 en endurance
        public override int Endurance
        {
            get { return base.Endurance + 1; }
        }

        public override int Force
        {
            get { return base.Force + 1; }
        }
    }
}
