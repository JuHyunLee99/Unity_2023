using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;   // 적들 배열
    [SerializeField]
    private GameObject boss;
    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f }; // 적 X축 위치
    [SerializeField]
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    public void stopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);    // 이 시간동안 잠시 대기

        float moveSpeed = 5f;   // 적 떨어지는 속도
        int spawnCount = 0;     // 지금까지 나타난 적 개수
        int enemyIndex = 0;     // 적종류 배열의 인덱스

        while(true)
        {
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex, moveSpeed);    // 해당위치에 랜덤 객체 생성
            }

            spawnCount++;
            if (spawnCount % 10 == 0)   // 10, 20, 30
            {
                enemyIndex++;
                moveSpeed += 2;
            }

            if(enemyIndex >= enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }
            yield return new WaitForSeconds(spawnInterval);    // 이 시간동안 잠시 대기
        }
    }
    void SpawnEnemy(float posX, int index, float moveSpeed)  // 객체 생성 함수
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if(Random.Range(0, 5) == 0) // 다른 레벨의 적도 조금씩 포함
        {   // 0, 1, 2, 3, 4 -> 0일 확률은 20%
            index += 1;     // 한단계 높은 레벨의 적
        }

        if(index >= enemies.Length) // 에러 방지
        {
            index = enemies.Length - 1; // 아무리 커도 배열의 마지막값으로
        }
        // 객체 생성하고 객체 정보 담음
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        // Enemy 클래스의 컴포넌트 받아와서 moveSpeed를  설정
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
