# Heroes Vs Monsters
 
Jeu en console écrit en C# (.NET), réalisé pendant ma formation .NET pour mettre en pratique la programmation orientée objet.
 
Dans la forêt de Shorewood, un héros (humain ou nain) affronte des monstres (loups, orques et dragonnets). Il récupère leur or et leur cuir, se repose après chaque victoire et continue jusqu'à sa mort ou jusqu'à ce que la forêt soit libérée.
 
## Fonctionnalités
 
- Deux modes de jeu, choisis depuis un menu :
  - **Combats successifs** : le héros enchaîne les monstres tirés au hasard jusqu'à sa mort.
  - **Plateau de 15 × 15** : 10 monstres cachés sont placés sur la carte. Le héros se déplace, et un combat démarre dès qu'il arrive à côté d'un monstre (horizontalement ou verticalement).
- Caractéristiques tirées aux dés : 4 dés à 6 faces, on garde les 3 meilleurs.
- Bonus selon la race, sans modifier les caractéristiques de base.
- Butin selon le monstre : le loup donne du cuir, l'orque de l'or, le dragonnet les deux.
## Lancer le jeu
 
Prérequis : le SDK .NET 10.
 
```bash
git clone https://github.com/11Marco-A/HeroesVsMonsters.git
cd HeroesVsMonsters
dotnet run --project HeroesVsMonsters
```
 
Ou ouvrir `HeroesVsMonsters.slnx` dans Visual Studio 2022 (version récente) et appuyer sur F5.
 
Sur le plateau : flèches ou ZQSD pour se déplacer, Échap pour quitter.
 
## Organisation du code
 
```
Personnage (abstraite)        Force, Endurance, PV, Frappe, position X/Y
├── Heros (abstraite)         Or, Cuir, Depouiller, SeReposer, Deplacer
│   ├── Humain                +1 Force, +1 Endurance
│   └── Nain                  +2 Endurance
└── Monstre (abstraite)
    ├── Loup      : IDepecable
    ├── Orque     : IPossedeOr              +1 Force
    └── Dragonnet : IPossedeOr, IDepecable  +1 Endurance
```
 
| Classe | Rôle |
|---|---|
| `De` | Dé avec un minimum, un maximum et une méthode `Lance()` |
| `FabriqueDeMonstres` | Crée un monstre au hasard |
| `Combat` | Déroule un combat tour par tour |
| `Plateau` | Grille de 15 × 15, placement des monstres et affichage |
| `Partie` | Déroulement des deux modes de jeu |
| `Program` | Point d'entrée et menu |
 
## Notions de POO mises en pratique
 
- **Encapsulation** : `Force`, `Endurance` et `PV` sont en lecture seule depuis l'extérieur.
- **Héritage et classes abstraites** : `Personnage` regroupe tout ce qui est commun aux héros et aux monstres.
- **Polymorphisme** : les bonus de race sont ajoutés avec `override`, et le jeu manipule des `Monstre` sans connaître leur type exact.
- **Interfaces** : `IPossedeOr` et `IDepecable` permettent au héros de récupérer le butin de n'importe quel monstre.
## Ce que j'aimerais ajouter
 
- Des tests unitaires sur le calcul des caractéristiques et des dégâts.
- Une sauvegarde du meilleur score.
- De nouveaux monstres, pour vérifier que le code s'étend sans modifier les classes existantes.
