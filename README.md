# 2048_test

R�gles du jeu:
- Faire glisser des tuiles sur une grille
- Utiliser les fl�ches pour d�placer les tuiles dans 4 direction
- Combiner les tuiles de m�mes valeurs
- Cr�er ainsi une tuile portant le nombre 2048
- Une tuile portant un 2 ou un 4 appara�t dans une case vide de mani�re al�atoire

Grille:
- une grille de 4 x 4

Tuiles:
- Il y a une tuile dans chaque case de la grille
- Les tuiles se deplacent toutes ensemble dans une direction jusqu'au bord du tableau ou jusqu'� une autre tuile.
- Une tuile portant un 2 ou un 4 appara�t dans une case vide de mani�re al�atoire

Mouvements:
- Utiliser les fl�ches pour effectuer 4 mouvements distincts(haut, bas, droite et gauche)
- Mouveent limit� par le bord de la grille
- Ce sont les tuiles qui bougent, la grille reste fixe
- Si deux tuile identique se touche lord du d�placement, elles fusionnent en une nouvelle tuile de valeur double

Score:

- Bas� sur les combinaisons de tuiles r�alis�es lors du jeu
- Le score du joueur est augment� de la valeur de la tuile r�sultante lorsque deux tuiles de m�me valeur fusionnent.