using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;   // ���� �迭
    [SerializeField]
    private GameObject boss;
    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f }; // �� X�� ��ġ
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
        yield return new WaitForSeconds(3f);    // �� �ð����� ��� ���

        float moveSpeed = 5f;   // �� �������� �ӵ�
        int spawnCount = 0;     // ���ݱ��� ��Ÿ�� �� ����
        int enemyIndex = 0;     // ������ �迭�� �ε���

        while(true)
        {
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex, moveSpeed);    // �ش���ġ�� ���� ��ü ����
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
            yield return new WaitForSeconds(spawnInterval);    // �� �ð����� ��� ���
        }
    }
    void SpawnEnemy(float posX, int index, float moveSpeed)  // ��ü ���� �Լ�
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if(Random.Range(0, 5) == 0) // �ٸ� ������ ���� ���ݾ� ����
        {   // 0, 1, 2, 3, 4 -> 0�� Ȯ���� 20%
            index += 1;     // �Ѵܰ� ���� ������ ��
        }

        if(index >= enemies.Length) // ���� ����
        {
            index = enemies.Length - 1; // �ƹ��� Ŀ�� �迭�� ������������
        }
        // ��ü �����ϰ� ��ü ���� ����
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        // Enemy Ŭ������ ������Ʈ �޾ƿͼ� moveSpeed��  ����
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
