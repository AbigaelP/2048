# 2048_test

Règles du jeu:
- Faire glisser des tuiles sur une grille
- Utiliser les flèches pour déplacer les tuiles dans 4 direction
- Combiner les tuiles de mêmes valeurs
- Créer ainsi une tuile portant le nombre 2048
- Une tuile portant un 2 ou un 4 apparaît dans une case vide de manière aléatoire

Grille:
- une grille de 4 x 4

Tuiles:
- Il y a une tuile dans chaque case de la grille
- Les tuiles se deplacent toutes ensemble dans une direction jusqu'au bord du tableau ou jusqu'à une autre tuile.
- Une tuile portant un 2 ou un 4 apparaît dans une case vide de manière aléatoire

Mouvements:
- Utiliser les flèches pour effectuer 4 mouvements distincts(haut, bas, droite et gauche)
- Mouveent limité par le bord de la grille
- Ce sont les tuiles qui bougent, la grille reste fixe
- Si deux tuile identique se touche lord du déplacement, elles fusionnent en une nouvelle tuile de valeur double

Score:

- Basé sur les combinaisons de tuiles réalisées lors du jeu
- Le score du joueur est augmenté de la valeur de la tuile résultante lorsque deux tuiles de même valeur fusionnent.