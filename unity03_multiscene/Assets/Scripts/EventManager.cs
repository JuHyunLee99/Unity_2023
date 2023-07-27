using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking.Types;

public class EventManager : MonoBehaviour
{
   public static EventManager Instance { get; private set; }

    // �г� ���� ��û �̺�Ʈ�� ����
    public event Action<string, string> OnPanelCreationRequested;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // �� ��ü�� �� ��ȯ �� �ı����� �ʵ��� ����
    }

    // �г� ���� ��û �Լ�
    public void RequestPanelCreation(string pinMapName, string cctvURL)
    {
        // �г� ���� ��û �̺�Ʈ�� �߻���Ŵ
        Debug.Log("�г� ���� ��û �̺�Ʈ�� �߻���Ŵ");
        OnPanelCreationRequested?.Invoke(pinMapName, cctvURL);
    }
}
