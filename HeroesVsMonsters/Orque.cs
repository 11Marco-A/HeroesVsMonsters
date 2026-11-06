using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    public class Orque : Monstre, IPossedeOr
    {
        public Orque(int x, int y) : base(x, y)
        {
            // l'orque a de l'or
            De de = new De(1, 6);
            Or = de.Lance();
        }

        public override string Nom
        {
            get { return "Orque"; }
        }

        public override char Symbole
        {
            get { return 'O'; }
        }

        // l'orque est plus fort que les autres
        public override int Force
        {
            get { return base.Force + 1; }
        }

        public int Or { get; }
    }
}
