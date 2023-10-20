
Unity2D-Study
Last Updated: 2023-10-20

Summary: Main Features & Skills
- Unity & C#
- Singleton
- Game Data Management using Json files
- Scene Management
- UI controls in scripts
This project is to practice and study game development using Unity.
I've named the whole project "Click Casual Games" as the games can be played just by clicks.


Currently the project consists of 3 games.
Pin Circle
Wave.io
ZigZag

0) Game Launcher

The scene is a game launcher for all games available.
Each button takes to a corresponding game.
The buttons aren't interactible until all the UIs show up(with the message "SELECT A GAME TO START")

![GameLauncher](https://github.com/Minwoo-K/Unity2D-Study/assets/112778695/2018e1df-c1a6-4539-9801-f8bf6b0fca3c)



1) Pin Circle

Pin Circle game is a simple dart game.
A player gets to throw pins(or darts) at a rotating target with pins.
The rule is to throw all the given pins each level, avoiding other pins on the target.
If you make it to throwing all the pins without touching other pins on the target, you win.
As you level up, you have the different number of pins to throw as well as different number of pins spawned on the target.

![PinCircle_01](https://github.com/Minwoo-K/Unity2D-Study/assets/112778695/33bc1d2b-1fbd-43e3-990e-0bbd3161e8dc)


2) Wave.io

In Wave.io game, a player is a ball.
The ball continuously moves left and right and only goes up while the player is clicking down.
The game has 10 different patterns with different obstacles to avoid.
And the player can only score when they take a score items.
As you level up, the ball's speed elevates and the width that the ball moves left and right gets narrower.

3) ZigZag

ZigZag game is a path game.
A player controls a direction of a ball, left and right, as the path spawns eternally.
The player can score as they pass a tile and score items.
As you level up, the speed of the ball increases.
