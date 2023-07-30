# Monster Attack Controller

[中文版](https://github.com/make-game-modules/monster-attack-controller/blob/main/README.zh-cn.md)

This project provides a Unity script, `MonsterAttackController`, that controls the attack behavior of monsters in the game. When attached to a game object, it damages a game object tagged as "Player" continuously upon contact. The script needs to be attached to a game object with a Collider2D component (set to Is Trigger), and the Player object should also have a CharacterHealthController component. The attack stops when the collision between the monster and the player ends.

## How to Install

In your Unity project, clone this repository at any location using Git.

## How to Use

1. Attach the `MonsterAttackController` script to the monster game object.
2. Set the `damageAmount` and `attackInterval` according to your game's requirements.
3. Make sure that the monster game object has a Collider2D component and it's set as a trigger.
4. Ensure the Player object has a CharacterHealthController component.

## Parameter Settings

- `damageAmount`: The damage caused by each attack.
- `attackInterval`: The time interval between attacks (in seconds).

## Operating Principle

The MonsterAttackController script uses the OnTriggerEnter2D and OnTriggerExit2D methods to start and stop the attack behavior respectively. A coroutine `ContinuousAttack` is used to perform damage to the player at a set interval while the monster and player are in contact.

## Other

If you encounter any issues or have suggestions, please open an issue on this repository.

## Copyright Information

This project uses the MIT open source license. Everyone is welcome to improve and use the project.
