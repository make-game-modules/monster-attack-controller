# 怪物攻击控制器

这个项目提供了一个 Unity 脚本，`MonsterAttackController`，它控制游戏中的怪物的攻击行为。当脚本挂载到游戏对象上，并且该对象碰到带有 "Player" 标签的游戏对象时，它会连续对该对象进行伤害。为了生效，这个脚本需要挂载到具有 Collider2D 组件（并且设置为 Is Trigger）的游戏对象上，而且 Player 对象上也应有 CharacterHealthController 组件。当怪物与玩家的碰撞结束后，攻击会停止。

## 如何安装

在 unity 项目中，任意位置使用 git clone 本仓库即可。

## 如何使用

1. 将 `MonsterAttackController` 脚本挂载到怪物游戏对象上。
2. 根据你的游戏需求设置 `damageAmount` 和 `attackInterval`。
3. 确保怪物游戏对象有 Collider2D 组件并设置为触发器。
4. 确保 Player 对象有 CharacterHealthController 组件。

## 参数设置

- `damageAmount`：每次攻击造成的伤害值。
- `attackInterval`：攻击的时间间隔（以秒为单位）。

## 运行原理

MonsterAttackController 脚本使用 OnTriggerEnter2D 和 OnTriggerExit2D 方法分别启动和停止攻击行为。当怪物与玩家接触时，使用一个协程 `ContinuousAttack` 在设定的间隔内对玩家进行伤害。

## 其他

如果你遇到任何问题或有建议，请在这个仓库中开一个 issue。

## 版权信息

本项目采用 MIT 开源许可证，欢迎任何人对项目的改进和使用。
