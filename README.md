
##Unity2D-Study
#### Last Updated: 2024-01-12
***
***Disclaimer: The contents in this project are not original of myself. The sources and codes are based on existing games and the project is mock merely for myself to study and practice Unity engine as well as Game Development process.

### Summary: Main Features & Skills
- `Unity` & `C#`
- Singleton
- Game Data Management using `Json` files
- Scene Management
- Trigometric Functions
- Camera Control
- Action & Events
- Object Manipulation
- Object Pooling
- UI controls in scripts
***
### Overview
This project is to practice and study game development using Unity.
I've named the whole project "Click Casual Games" as the games can be played just by clicks.

Currently the project consists of 3 games.
###### Pin Circle
###### Wave.io
###### ZigZag

### 1. Game Launcher

The scene is a game launcher for all games available.
Each button takes to a corresponding game.
The buttons aren't interactible until all the UIs show up(with the message "SELECT A GAME TO START")

![GameLauncher](https://github.com/Minwoo-K/Unity2D-Study/assets/112778695/bf2c517c-c0e5-4120-b0c1-62fc7adb92a8)


### 2. Pin Circle

Pin Circle game is a simple dart game.
A player gets to throw pins(or darts) at a rotating target with pins.
The rule is to throw all the given pins each level, avoiding other pins on the target.
If you make it to throwing all the pins without touching other pins on the target, you win.
As you level up, you have the different number of pins to throw as well as different number of pins spawned on the target.

#### Main Features
- Trigometric Functions
- UI control in scripts with Coroutine
- Camera Control
- Action & Events

![PinCircle_play](https://github.com/Minwoo-K/Unity2D-Study/assets/112778695/aa1bc5c2-4c67-4e3e-98eb-f0dc56823fce)


### 3. Wave.io

In Wave.io game, a player is a ball.
The ball continuously moves left and right and only goes up while the player is clicking down.
The game has 10 different patterns with different obstacles to avoid.
And the player can only score when they take a score items.
As you level up, the ball's speed elevates and the width that the ball moves left and right gets narrower.

#### Main Features
- Object Manipulation in scripts(position, rotation, scales, etc.)
- Trigometric Functions
- Built-in Particle effect

![Waveio_play](https://github.com/Minwoo-K/Unity2D-Study/assets/112778695/b8899041-ba3b-44a4-b6b3-15acce91585e)


 ### 4. ZigZag

ZigZag game is a path game.
A player controls a direction of a ball, left and right, as the path spawns eternally.
The player can score as they pass a tile and score items.
As you level up, the speed of the ball increases.

#### Main Features
- Object Pooling
- UI Control in scripts

![ZigZag_play](https://github.com/Minwoo-K/Unity2D-Study/assets/112778695/c57095fa-84cd-4f8a-8a16-50e6116e6e82)

