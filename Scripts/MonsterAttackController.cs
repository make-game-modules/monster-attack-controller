using System.Collections;
using UnityEngine;

/// <summary>
/// MonsterAttackController 类控制怪物的攻击行为。
/// 当挂载到游戏对象上，并且该对象碰到带有 "Player" 标签的游戏对象时，它会连续对该对象进行伤害。
/// 为了生效，这个脚本需要挂载到具有 Collider2D 组件（并且设置为 Is Trigger）的游戏对象上，
/// 而且 Player 对象上也应有 CharacterHealthController 组件。
/// 攻击行为会在怪物与玩家的碰撞结束后停止。
/// </summary>
public class MonsterAttackController : MonoBehaviour
{
    /// <summary>
    /// 每次攻击造成的伤害值。
    /// </summary>
    public int damageAmount = 1;

    /// <summary>
    /// 攻击的时间间隔（以秒为单位）。
    /// </summary>
    public float attackInterval = 1f;

    /// <summary>
    /// 被攻击的玩家的 CharacterHealthController 引用。
    /// </summary>
    private CharacterHealthController targetPlayer;

    /// <summary>
    /// 用于停止和启动攻击协程的 Coroutine 对象引用。
    /// </summary>
    private Coroutine attackCoroutine;

    /// <summary>
    /// 当怪物的 Collider2D 与另一个 Collider2D（玩家）接触时，会触发该方法。
    /// 当玩家进入怪物的触发区域时，会开始连续的攻击协程。
    /// </summary>
    /// <param name="other">碰撞的 Collider2D 对象</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // 确认碰撞的对象是否为玩家
        {
            targetPlayer = other.gameObject.GetComponent<CharacterHealthController>(); // 获取玩家的 CharacterHealthController
            if (targetPlayer != null) // 确认是否成功获取到
            {
                attackCoroutine = StartCoroutine(ContinuousAttack()); // 如果获取成功，开始连续攻击协程
            }
        }
    }

    /// <summary>
    /// 当怪物的 Collider2D 不再和另一个 Collider2D（玩家）接触时，会触发该方法。
    /// 当玩家离开怪物的触发区域时，会停止连续的攻击协程。
    /// </summary>
    /// <param name="other">碰撞的 Collider2D 对象</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && attackCoroutine != null) // 确认离开的对象是否为玩家，并且正在进行连续攻击
        {
            StopCoroutine(attackCoroutine); // 停止连续攻击协程
            attackCoroutine = null; // 清除协程引用
            targetPlayer = null; // 清除玩家引用
        }
    }

    /// <summary>
    /// ContinuousAttack 是一个协程，负责实现怪物的连续攻击行为。
    /// 在玩家进入怪物的触发区域时开始，并在玩家离开后停止。
    /// 这个协程每隔一段时间（由 attackInterval 控制）对玩家造成一次伤害（伤害值由 damageAmount 控制）。
    /// </summary>
    private IEnumerator ContinuousAttack()
    {
        while (true) // 持续循环，直到协程被停止
        {
            targetPlayer.TakeDamage(damageAmount); // 对玩家进行一次伤害
            yield return new WaitForSeconds(attackInterval); // 等待设定的时间间隔
        }
    }
}
