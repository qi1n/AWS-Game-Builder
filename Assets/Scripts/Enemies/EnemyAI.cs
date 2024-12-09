using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //public float amplitude = 1f; // �߶Ȳ�����Χ
    //public float frequency = 1f; // ����Ƶ��

    //private Vector3 initialPosition;

    //void Start()
    //{
    //    // �����ʼλ��
    //    initialPosition = transform.position;
    //}

    //void Update()
    //{
    //    // ʹ�����Ҳ���̬�����߶�
    //    float newY = initialPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
    //    transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    //}

    private enum State { 
        Roaming
    }

    private State state;
    private EnemyPath enemyPath;
    private void Awake()
    {
        enemyPath = GetComponent<EnemyPath>();
        state = State.Roaming; // ����״̬
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming) {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPath.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
