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
            instance = this;    // 게임매니저를 대입
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());

        if (coin % 10 == 0) // 코인 30일때마다 무기 업그레이드
        {
            Player player = FindObjectOfType<Player>(); // 게임에서의 play를 찾아줌
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

        Invoke("ShowGameOverPanel", 1f); // 1초뒤에 showgameoverpanel 함수 동작
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
