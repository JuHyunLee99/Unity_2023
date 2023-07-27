using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking.Types;

public class EventManager : MonoBehaviour
{
   public static EventManager Instance { get; private set; }

    // 패널 생성 요청 이벤트를 정의
    public event Action<string, string> OnPanelCreationRequested;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // 이 객체가 씬 전환 시 파괴되지 않도록 설정
    }

    // 패널 생성 요청 함수
    public void RequestPanelCreation(string pinMapName, string cctvURL)
    {
        // 패널 생성 요청 이벤트를 발생시킴
        Debug.Log("패널 생성 요청 이벤트를 발생시킴");
        OnPanelCreationRequested?.Invoke(pinMapName, cctvURL);
    }
}
