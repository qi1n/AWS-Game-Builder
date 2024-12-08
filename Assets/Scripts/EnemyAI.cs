using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //public float amplitude = 1f; // 高度波动范围
    //public float frequency = 1f; // 波动频率

    //private Vector3 initialPosition;

    //void Start()
    //{
    //    // 保存初始位置
    //    initialPosition = transform.position;
    //}

    //void Update()
    //{
    //    // 使用正弦波动态调整高度
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
        state = State.Roaming; // 漫游状态
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
