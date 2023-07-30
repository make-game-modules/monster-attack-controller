using System.Collections;
using UnityEngine;

/// <summary>
/// MonsterAttackController ����ƹ���Ĺ�����Ϊ��
/// �����ص���Ϸ�����ϣ����Ҹö����������� "Player" ��ǩ����Ϸ����ʱ�����������Ըö�������˺���
/// Ϊ����Ч������ű���Ҫ���ص����� Collider2D �������������Ϊ Is Trigger������Ϸ�����ϣ�
/// ���� Player ������ҲӦ�� CharacterHealthController �����
/// ������Ϊ���ڹ�������ҵ���ײ������ֹͣ��
/// </summary>
public class MonsterAttackController : MonoBehaviour
{
    /// <summary>
    /// ÿ�ι�����ɵ��˺�ֵ��
    /// </summary>
    public int damageAmount = 1;

    /// <summary>
    /// ������ʱ����������Ϊ��λ����
    /// </summary>
    public float attackInterval = 1f;

    /// <summary>
    /// ����������ҵ� CharacterHealthController ���á�
    /// </summary>
    private CharacterHealthController targetPlayer;

    /// <summary>
    /// ����ֹͣ����������Э�̵� Coroutine �������á�
    /// </summary>
    private Coroutine attackCoroutine;

    /// <summary>
    /// ������� Collider2D ����һ�� Collider2D����ң��Ӵ�ʱ���ᴥ���÷�����
    /// ����ҽ������Ĵ�������ʱ���Ὺʼ�����Ĺ���Э�̡�
    /// </summary>
    /// <param name="other">��ײ�� Collider2D ����</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // ȷ����ײ�Ķ����Ƿ�Ϊ���
        {
            targetPlayer = other.gameObject.GetComponent<CharacterHealthController>(); // ��ȡ��ҵ� CharacterHealthController
            if (targetPlayer != null) // ȷ���Ƿ�ɹ���ȡ��
            {
                attackCoroutine = StartCoroutine(ContinuousAttack()); // �����ȡ�ɹ�����ʼ��������Э��
            }
        }
    }

    /// <summary>
    /// ������� Collider2D ���ٺ���һ�� Collider2D����ң��Ӵ�ʱ���ᴥ���÷�����
    /// ������뿪����Ĵ�������ʱ����ֹͣ�����Ĺ���Э�̡�
    /// </summary>
    /// <param name="other">��ײ�� Collider2D ����</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && attackCoroutine != null) // ȷ���뿪�Ķ����Ƿ�Ϊ��ң��������ڽ�����������
        {
            StopCoroutine(attackCoroutine); // ֹͣ��������Э��
            attackCoroutine = null; // ���Э������
            targetPlayer = null; // ����������
        }
    }

    /// <summary>
    /// ContinuousAttack ��һ��Э�̣�����ʵ�ֹ��������������Ϊ��
    /// ����ҽ������Ĵ�������ʱ��ʼ����������뿪��ֹͣ��
    /// ���Э��ÿ��һ��ʱ�䣨�� attackInterval ���ƣ���������һ���˺����˺�ֵ�� damageAmount ���ƣ���
    /// </summary>
    private IEnumerator ContinuousAttack()
    {
        while (true) // ����ѭ����ֱ��Э�̱�ֹͣ
        {
            targetPlayer.TakeDamage(damageAmount); // ����ҽ���һ���˺�
            yield return new WaitForSeconds(attackInterval); // �ȴ��趨��ʱ����
        }
    }
}
