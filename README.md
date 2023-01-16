# Project: Planeshifter
## One Liner
Project: Planeshifter is a 2D Runner game in which the player will have to use the stunning ability to change between planes of reality in order to create paths that allow them to reach the goal in each level.

## Basic Mechanics
As an autorunner, the main character will move on their own, thus, leaving the player with just two mechanics:
- **Jump**: the character can jump and, when used against walls, they can wall-jump and change run direction.
- **Planeshifting**: there are paths that can only be used when they are in the correct plane of reality. The character has the ability to change between the two realms to walk over these paths.

## Dynamics
- The game requires the player to use the basic mechanics with the correct timing to move forward to the level.
- In order to find the path to reach the goal, the player would need to change the direction, colliding with non-letal walls.

## Enemies and Dangers
Reaching the goal won't be a piece of cake. The player must evade triangular enemies and spikes present in the levels while taking care of not falling into the abyss. The player can find three types of enemies in the game:
- **X Enemies**: These enemies can only move themselves horizontally. When thy reach at the end of their paths (at the end of a platform or when they collide with a wall), they turn around and walk in the invert direction.
- **Y Enemies**: These enemies can only move themselves vertically. They have the same logic that the **X Enemies**, but with vertical movement.
- **Z Enemies**: These enemies will be buried in the ground and will jump to try and hit the player when the character is near. The player will have to avoid them just by walking when they are at the highest point, this means, the player doesn't have to jump.
These enemies need to be evaded in every ocasion. Confrontation is not an option.

## Art Style
As a minimalist art, the game doesn't have complex visual design. It is componed by simple shapes and colors with different functions:
- **Player**: The player is a yellow circle that stands out agains the background. It is always visible by the player.
- **Enemies**: The enemies are red triangles that also stand out agains the background. They are seeing with enough time to evade them.
- **Spikes**: The spikes are static enemies that will kill the player if he touchs them. They will have almost the same color as the main platform or floor, but sightly different, maybe more dark to contrast with the background.
- **Basic Platforms**: The platforms are dark-grey rectangles (with circular edges), and they are the only walkable element in all the game.
- **Plane Platforms**: The platforms that can change between planes are blue and orange rectangles (also with circular edges). When the player is in its right plane, the platform is saturated blue or orange, but if the player is in the other plane, the platform swith into a grey blue or grey orange.
- **Goal**: The goal is composed by a green platform and a green flag.
- **Background**: The background is composed by a grey scale, with a subtle blue or orange, depending on the plane the player is, so it doesn't distract the player for the obstacles and the goal.

## Lore

## Levels
In **Project: Planeshifter** levels are BIG. The player moves horizontally to the right most of the time, but there will be ocasions in which the player will need to change the direction, ascend or go down by different paths to find the goal.
There will be **at least** 3 levels:
- **Level 0 (Tutorial)**: The main objective of this level is to teach the player the basic navigation through the level and mechanics, which is basically jump, wall jump and change planes.
- **Level 1**: The main objective of this level is to introduce the negative elements of the game; the enemies and the spikes. Of course, the player will also put in practice what he learned in the previous level.
- **Level 2**: This will be the first **complete level**, which will be composed of every element of the game without the objective of teach the player anything.
Having these 3 levels, we can make some more in order to design diferent fun levels.

### Camera
The player will be moving every time, so he needs to see a several part of the map in his current position to not die unfairly. The player is located in 1/3 of the X axis to be always visible when the screen is tapped.

## Controls
There are only two possible inputs, jump and shift planes. Talking about input, the screen is divided in two parts, the left and the right:
- **Left**: The left part of the screen has the **jump** input. The player will be mostly moving to the right, so the left part will be "useless", and the jump action is so basic that the player should do it almost without thinking too much.
- **Right**: The right part of the screen has the **shift planes** input. For the same reason than above, the main obstacles and "plane platforms" will be on the right part of the screen, so that part will be the main focus of the player. For this reason, is natural that the player uses that part of the screen to use the "shift planes" action, which is a more active action than jumping.
