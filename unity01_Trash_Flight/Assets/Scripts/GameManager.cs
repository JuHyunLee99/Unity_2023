using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    private int coin = 0;
    [HideInInspector]
    public bool isGameOver = false;

    [SerializeField]
    private GameObject gameOverPanel;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;    // ���ӸŴ����� ����
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());

        if (coin % 10 == 0) // ���� 30�϶����� ���� ���׷��̵�
        {
            Player player = FindObjectOfType<Player>(); // ���ӿ����� play�� ã����
            player.Upgrade();
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if(enemySpawner != null)
        {
            enemySpawner.stopEnemyRoutine();
        }

        Invoke("ShowGameOverPanel", 1f); // 1�ʵڿ� showgameoverpanel �Լ� ����
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);  
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
