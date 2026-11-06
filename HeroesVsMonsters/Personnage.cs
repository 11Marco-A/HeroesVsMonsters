using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesVsMonsters
{
    public abstract class Personnage
    {
        // dés pour les caractéristiques et les dégâts
        private static De _d4 = new De(1, 4);
        private static De _d6 = new De(1, 6);

        private int _enduranceDeBase;
        private int _forceDeBase;

        protected Personnage(int x, int y)
        {
            X = x;
            Y = y;

            // lancer les caractéristiques au début
            _enduranceDeBase = LancerCaracteristique();
            _forceDeBase = LancerCaracteristique();

            // les PV commencent au maximum
            PV = PVMaximum;
        }

        public abstract string Nom { get; }
        public abstract char Symbole { get; }

        public virtual int Endurance
        {
            get { return _enduranceDeBase; }
        }

        public virtual int Force
        {
            get { return _forceDeBase; }
        }

        // points de vie actuels
        public int PV { get; private set; }

        public int PVMaximum
        {
            get
            {
                // le max de PV c'est l'endurance + son modificateur
                return Endurance + GetModificateur(Endurance);
            }
        }

        public bool EstVivant
        {
            get
            {
                if (PV > 0)
                    return true;
                else
                    return false;
            }
        }

        public int X { get; protected set; }
        public int Y { get; protected set; }

        public int Frappe(Personnage cible)
        {
            int degats = _d4.Lance() + GetModificateur(Force);
            cible.PV -= degats;
            return degats;
        }

        public override string ToString()
        {
            int pvAffiche = PV;
            if (pvAffiche < 0)
                pvAffiche = 0;

            return Nom + " (For " + Force + ", End " + Endurance
                + ", PV " + pvAffiche + "/" + PVMaximum + ")";
        }

        protected void RestaurerPV()
        {
            PV = PVMaximum;
        }

        // retourne le modificateur selon la valeur de la caractéristique
        private static int GetModificateur(int carac)
        {
            int mod = 0;

            if (carac < 5)
            {
                mod = -1;
            }
            else if (carac < 10)
            {
                mod = 0;
            }
            else if (carac < 15)
            {
                mod = 1;
            }
            else
            {
                mod = 2;
            }

            return mod;
        }

        private static int LancerCaracteristique()
        {
            // on lance 4d6 et on enlève le plus petit résultat
            int total = 0;
            int plusPetit = _d6.Maximum;

            for (int i = 0; i < 4; i++)
            {
                int r = _d6.Lance();
                total = total + r;
                if (r < plusPetit)
                {
                    plusPetit = r;
                }
            }

            return total - plusPetit;
        }
    }
}
