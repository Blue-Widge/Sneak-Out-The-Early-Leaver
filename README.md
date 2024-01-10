# ShooterVR



#### Baudoin Thomas  - Lemaire Yann

##### 4A ESIEA LAVAL | 2023 - 2024

# Sneak Out : The Early Leaver

Le jeu est basé sur la discrétion et l'infiltration. Il faut éliminer les ennemis avec le pistolet ou les couteaux mis à disposition sur la carte. L'objectif est de ne pas se faire repérer si vous ne voulez pas revenir au point de départ ! Différentes zones de sécurité, colorées en vert, sont positionnées dans les différents bureaux où les ennemis ne peuvent pas vous voir. Une fois les ennemis éliminés ou évités, une porte ouverte marquée d'une zone de sécurité au sol vous permettra de gagner. Vous pouvez interagir avec une multitude d'objets, mais seuls les couteaux et le pistolet peuvent tuer.

##### Attention au son il peut être fort !

##### Menu de début :
- Bouton "Start" pour commencer le jeu
- Bouton "Quit" pour quitter le jeu

##### Menu de fin :
- Bouton "Restart" pour recommencer une partie
- Bouton "Quit" pour quitter le jeu

##### Contrôles :
- Select : prendre les objets
- Trigger : tirer avec le pistolet
- Joystick gauche pour se déplacer
- Joystick droit pour touner la caméra

##### Crédits :
- https://assetstore.unity.com/packages/3d/props/voxel-office-props-127772
- https://assetstore.unity.com/packages/3d/props/interior/door-free-pack-aferar-148411
- https://www.youtube.com/watch?v=GnY2UdUKXs0
- https://www.youtube.com/watch?v=rzxLd9M5yp8
- https://quaternius.com/packs/ultimatemodularcharacters.html
- https://kenney.nl/assets/weapon-pack
- https://pixabay.com for footsteps sound

### TP PROGRAMMATION DÉDIÉE RV


## Introduction

Le but du projet est de développer une expérience VR courte, de type Shooter.

Pour des références, vous pouvez vous renseigner sur internet. Des classiques du genre sont :

- Super Hot
- Pistol Whip
- The Lab

Le sujet suivant se présente comme un cahier des charges des fonctionnalités minimales attendues. L’objectif
de ce projet réside surtout dans le développement d’un gameplay en VR.

Vous trouverez tout de même des modèles 3D sur l’Asset Store, ou dans les ressources ci-dessous ou pourrez
simplement utiliser les primitives d’Unity. L’usage de plugin ou de librairies de code C# de l’Asset Store est
cependant prohibé.

Quoi qu’il en soit l’ensemble des éléments de votre projet qui ne sont pas produit durant le temps du TP
(modèles 3D, sons, ...) devront être crédités lors du rendu du projet.


## Modalités

Voici les modalités :

- Ce projet est à réaliser en binôme
- Ce projet devra être fait avec **Unity 202 1 .3. 33 f1** avec le Default Renderer ou URP
- Ce projet devra être fait pour la plateforme Oculus VR, sur PC
- Ce projet sera à rendre le **mercredi 10 janvier à 16h**
- Ce projet devra être rendu par e-mail, à l’adresse **antoine.cherel@ext.esiea.fr**
    o En objet : NOM1 Prénom1 – NOM2 Prénom
    o Dans le contenu du mail :
       ▪ Le nom de votre Jeu
       ▪ Une très brève description
       ▪ Un lien vers le projet sous Git (GitHub, GitLab...) en **public** ou en **non-répertorié**
       ▪ Vos crédits
       ▪ Vos noms & prénoms à nouveau

## Ressources

#### Modèles 3D

- https://kenney.nl/assets/category:3D?sort=update
- https://kaylousberg.com/game-assets
- https://quaternius.com/index.html

#### Sons

- https://freesound.org/ (besoin de créer un compte gratuitement)

#### Musiques

- https://filmmusic.io/ (besoin de créer un compte gratuitement)


## Sujet minimum

L’objectif est donc de développer un Shooter en VR. Vous êtes totalement libre dans votre développement
mais le projet devra contenir une liste de contraintes techniques, à savoir :

### Un menu Démarrer

Votre projet sera composé d’au moins deux scènes, un menu démarrer et la scène de jeu. Pour la scène de
démarrage, vous devez utiliser le XR UI Canvas pour faire un menu de lancement du jeu. Vous pouvez aussi
profiter de cette scène pour créditer les éléments dont vous vous êtes servis.

### Des déplacements dans la scène

Vous devrez choisir un système de locomotion dans la scène. Vous pourrez choisir entre les différents
systèmes vus en cours, ou une combinaison d’entre eux.

### Un objet interactif

Vous devrez ajouter la possibilité d’utiliser des équipements interactifs comme des arcs, lampes torche,
pistolets, spray, télécommande, ...

### L’ajout d’objets préhensibles

Plusieurs objets devront être "interactif" dans votre scène. A vous d’imaginer la meilleure façon de les mettre
à contribution (ou pas) dans votre expérience.

Par exemple : des chargeurs, des flèches, des batteries, des armes de jets, des boites de conserve, etc...

### La Gestion du Game Over et du Score

Votre projet étant un Shooter, il doit comporter un système de score, à afficher en World Space, dans le
monde, ou sur une arme ou dans le champ de vision du joueur. Le jeu doit aussi avoir une fin, que ça soit un
timer, un nombre de vie, etc...

La durée de vie du jeu ne devrait pas excéder quelques minutes.


## Contenu bonus

En plus du sujet de base, une fois celui-ci fini (ou presque), n’hésitez pas à ajouter des fonctionnalités
supplémentaires afin de rendre votre jeu plus intéressant. Voici quelques exemples de fonctionnalités qui
seront valorisées.

### Du Son

Vous pourrez rajouter du son lors d’interactions, une musique d’ambiance, une voix off.

### Des VFX

Vous pourrez rajouter des effets visuels lors d’interactions, des animations ou des effets de particules.

### Un Scénario plus poussé

Vous pourrez imaginer un scénario plus développé autour de votre jeu. Qu’on comprenne mieux sur quoi et
pourquoi on tire.


