# Project: Planeshifter
## One Liner
Project: Planeshifter is a 2D Runner game in which the player will have to use the stunning ability to change between planes of reality in order to create paths that allow them to reach the goal in each level.

## Basic Mechanics
As an autorunner, the main character will move on their own, thus, leaving the player with just two mechanics:
- **Jump**: the character can jump and, when used against walls, they can wall-jump and change run direction.
- **Planeshifting**: there are paths that can only be used when they are in the correct plane of reality. The character has the ability to change between the two realms to walk over these paths.

## Dynamics
- The game requires the player to use the basic mechanics with the correct timing to move forward to the level.
- In order to find the path to reach the goal, the player would need to change the direction, colliding with non-letal walls (walls without spikes).

## Enemies and Dangers
Reaching the goal won't be a piece of cake. The player must evade triangular enemies and spikes present in the levels while taking care of not falling into the abyss. The player can find three types of enemies in the game:
- **X Enemies**: These enemies can only move themselves horizontally, only when the player is near them. When thy reach at the end of their paths (at the end of a carril in which they are attached), they turn around and walk in the invert direction. This can be seeing in the bright part of the enemy. When they change the direction, the bright part also change when the enemy is stopped (a very short time). This enemies can only stop at the end of the carril, so if the player is enough far from the enemy to be stopped, this will stop in an extreme of the carril.
- **Y Enemies**: These enemies can only move themselves vertically. They have the same logic that the **X Enemies**, but with vertical movement.
- 
![](https://github.com/Sanrro10/JanuaryProject/blob/main/Assets/Art/Sprites/horizontal_enemy_leftActive.png)
![](https://github.com/Sanrro10/JanuaryProject/blob/main/Assets/Art/Sprites/horizontal_enemy_rightActive.png)

## Art Style
As a minimalist art, the game doesn't have complex visual design. It is componed by simple shapes and colors with different functions:
- **Player**: The player is a yellow circle that stands out agains the background. It is always visible by the player.
- **Enemies**: The enemies are red triangles that also stand out agains the background. They are seeing with enough time to evade them.
- **Spikes**: The spikes are static enemies that will kill the player if he touchs them. They will have almost the same color as the main platform or floor, but slightly different, maybe more dark to contrast with the background. The spikes will appear on floor, walls and ceiling. They can also belong to the color panels, so they can be blue and orange. In this case, they can be activated and deactivated by switching planes.
- **Basic Platforms**: The platforms are dark-grey rectangles (with circular edges), and they are the only walkable element in all the game.
- **Plane Platforms**: The platforms that can change between planes are blue and orange rectangles (also with circular edges). When the player is in its right plane, the platform is saturated blue or orange, but if the player is in the other plane, the platform swith into a grey blue or grey orange.
- **Goal**: The goal is composed by a green platform and a green flag.
- **Background**: The background is composed by a grey scale, with a subtle blue or orange, depending on the plane the player is, so it doesn't distract the player for the obstacles and the goal.

## Lore
Bolinche was a **normal ball** that just went around the Round world. They always rolled around everywere without any special worry. They was a ball and they liked balls, everything was simple. 

But one day, things changed. Suddenly, Bolinche unintentionally **changed between dimensions**. Was something like that possible? Well, Bolinche did it, so it seems so. But they didn't know how that change occurred, so they didn't know how to go back to their round dimension. Now they were **trapped** in a strange dimension of squares, rectagles and even triangles! But, for some reason, they can **shift between planes**, alternating the blue and the orange dimension. They still didn't know how they were doing that thing, but one thing was clear: they will find they way to **return to their original dimension**.

Time passed, and Bolinche learned a bit how to use those strange super powers, but they felt **lonely**. They can see through all those dimensions, but it seems nobody can notice Bolinche. Everywhere they went, thing seemed **dangerous and hostile**. Bolinche could not help but feel threatened. However, they didn't give up, and continue forging ahead with the hope of return to the round dimension.

During the journey, Bolinche experimented the loneliness from different points of view:
- **Social**: They were completely alone. There were a lot of beings and things around there, yes, but Bolinche didn't understand a thing. They could communicate with nobody, they felt they were they last ball in every dimension.
- **Emotional**: Feeling like the last ball in all existence was painful, a very concrete way of feeling alone.
- **Existential**: What if they could never return? Whas if they was trapped eternally? What was the meaning of life then?

As they moved forward, Bolinche found a balance in the journey. They were understanding how the different dimensions works, and they were discovering things that every ball would find incomprehensible. Bolinche was the only ball that was allowed to see all those amazing things, and they have masterized the plane shifting. Maybe... this was their destiny? Travel around the never-ending dimensions and grow? They didn't know, but they were more confortable with their situation. **Journey before destination**

## Levels
In **Project: Planeshifter** levels are BIG. The player moves horizontally to the right most of the time, but there will be ocasions in which the player will need to change the direction, ascend or go down by different paths to find the goal.
There will be **at least** 3 levels:
- **Level 0 (Tutorial)**: The main objective of this level is to teach the player the basic navigation through the level and mechanics, which is basically jump, wall jump and change planes.
- **Level 1**: The main objective of this level is to introduce the negative elements of the game; the enemies and the spikes. Of course, the player will also put in practice what he learned in the previous level.
- **Level 2**: This will be the first **complete level**, which will be composed of every element of the game without the objective of teach the player anything.
Having these 3 levels, we can make some more in order to design diferent fun levels.
Levels can be selected by the **Select Level** screen. The player can slide between levels and play the level he wants (if it is unlocked). Every level must be unlocked be completing the previous level. Level 0 is always unlocked.

### Camera
The player will be moving every time, so he needs to see a several part of the map in his current position to not die unfairly. The player is located in 3/7 or 4/7 of the X axis to be always visible when the screen is tapped.

## Controls
There are only two possible inputs, jump and shift planes. Talking about input, the screen is divided in two parts, the left and the right:
- **Left**: The left part of the screen has the **jump** input. The player will be mostly moving to the right, so the left part will be "useless", and the jump action is so basic that the player should do it almost without thinking too much.
- **Right**: The right part of the screen has the **shift planes** input. For the same reason than above, the main obstacles and "plane platforms" will be on the right part of the screen, so that part will be the main focus of the player. For this reason, is natural that the player uses that part of the screen to use the "shift planes" action, which is a more active action than jumping.

## Screens Flow
![](https://github.com/Sanrro10/JanuaryProject/blob/main/Others/Screens%20Flow.png)

The player can navigate between screens by clicking on the different buttons, but some other buttons open "sub-screens", instead of change to another screen.
