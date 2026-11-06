using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    public abstract class Heros : Personnage
    {
        protected Heros(int x, int y) : base(x, y)
        {
        }

        public override char Symbole
        {
            get { return 'H'; }
        }

        // quantité d'or et de cuir que le héros a récupéré
        public int Or { get; private set; }
        public int Cuir { get; private set; }

        public void Depouiller(Monstre monstre)
        {
            // on peut pas dépouiller un monstre encore vivant
            if (monstre.EstVivant == true)
            {
                return;
            }

            // récupérer l'or si le monstre en a
            if (monstre is IPossedeOr)
            {
                IPossedeOr monstreAvecOr = (IPossedeOr)monstre;
                Or = Or + monstreAvecOr.Or;
            }

            // récupérer le cuir si le monstre en a
            if (monstre is IDepecable)
            {
                IDepecable monstreDepecable = (IDepecable)monstre;
                Cuir = Cuir + monstreDepecable.Cuir;
            }
        }

        public void SeReposer()
        {
            // le héros récupère tous ses PV
            RestaurerPV();
        }

        public void Deplacer(int dx, int dy)
        {
            X = X + dx;
            Y = Y + dy;
        }

        public override string ToString()
        {
            return base.ToString() + " - Or : " + Or + ", Cuir : " + Cuir;
        }
    }
}
