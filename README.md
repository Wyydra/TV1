# TV1

# I Les difficultés liées à la validation
1. Manque de modularité: Le code n'est pas divisé en modules ou classes
   distinctes pour séparer les responsabilités, compliquant la 
   maintenance et les tests.

2.  Peu de méthodes renvoient de valeurs, ce qui rends difficile la 
    vérification des résultats.

3. Manque de lisibilité: L'utilisation de noms de variables peu explicites
   rend le code difficile à comprendre et à entretenir.

4. Duplication du code: La duplication du code, notamment dans les conditions
   de vérification de victoire, rend les modifications plus difficiles et 
   augmente la complexité du code et rends difficile la généralisation des tests.
   augmentant le risque d'oubli ou d'erreur.

5. Dépendance aux E/S: Le code utilise directement la classe Console pour
   afficher des messages à l'utilisateur, ce qui rends difficile la
   simulation des entrées/sorties lors des tests.

6. Manque de gestion d'erreurs: Le code ne gère pas correctement les erreurs,
   rendant les tests de gestion des erreurs plus difficiles à mettre en place.

7. Les méthodes dans le code actuel sont excessivement longues avec de nombreux niveaux 
   d'indentation, ce qui empêche des les réutiliser et de les tester correctement.

# Les méthodes de résolution de ces problèmes
L'objectif est de restructurer une partie du code pour permettre des tests automatisés 
et d'ajouter des tests pour vérifier les modifications sans affecter le fonctionnement 
du projet. 

Les premiers tests ont révélé des erreurs, dans les conditions de victoire notamment.
Il existe également des bugs d'affichage qui ne peuvent pas être détectés par des tests
à cause du couplage fort du code actuel avec la classe Console.

## Restructuration du code
Une partie des logiques annexes au jeu a été déplacée dans des classes distinctes pour
séparer les responsabilités et faciliter les tests. La sauvagarde et le chargement des 
parties ont été déplacées et peuvent être testées indépendamment du reste du code.

La classe `Game` réprente le jeu et est responsable de la logique de jeu. C'est une classe
abstraite qui peut être étendue pour implémenter des jeux différents. 

La loqique de changement de joueur peut être réimplémentée par une classe fille de la classe
`Game` au lieu d'utiliser une méthode abstraite non visible à l'extérieur de la classe. La logique
a été déplacée dans un classe à part `ISwitchPlayerStrategy` qui peut être testée indépendamment.

Le même raisonnement a été appliqué à la représentation du plateau de jeu, qui a été déplacée dans une
classe à part `Grid` qui peut être testée indépendamment.

les E/S se font par l'intermédiaire d'InputService et OutputService permettant de découpler le code de la console
ces services peuvent être mockés pour les tests.

# Le développement des fonctionnalités manquantes

## Jouer contre un ordinateur
Une classe abstraite `Player` a été ajoutée pour représenter les joueurs. Les classes `HumanPlayer` et `AIPlayer`
ont été ajoutées pour représenter les joueurs humains et les bots et leur comportement.

## Sauvegarder et charger une partie
La sauvegarde et le chargement des parties ont été déplacées dans des classes à part, pour les même raisons que 
précédemment, pour séparer les responsabilités et faciliter les tests. La sauvegarde et le chargement se font dans des fichiers JSON par défaut.