using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    // ���� ������ Ŭ������ �ν��ͽ��� ��� ������ ����
    public SensorData Sensor_Data;

    // �г� ���� ��û �̺�Ʈ�� ����
    public event Action<MapPinInfo> OnPanelCreationRequested;
    public event Action<MapPinInfo> OnPanelDestructionResponsed;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("EventManager.Instance ����");
            Instance = this;
            Sensor_Data = new SensorData();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); // �� ��ü�� �� ��ȯ �� �ı����� �ʵ��� ����
    }

    // �г� ���� ��û �Լ�
    public void RequestPanelCreation(MapPinInfo mapPinInfo)
    {
        // �г� ���� ��û �̺�Ʈ�� �߻���Ŵ
        Debug.Log("�г� ���� ��û �̺�Ʈ�� �߻���Ŵ");
        OnPanelCreationRequested?.Invoke(mapPinInfo);

    }
    // �г� �ı� ���� �Լ�
    public void ResponsePanelDestruction(MapPinInfo mapPinInfo)
    {
        // �г� �ı� ���� �̺�Ʈ�� �߻���Ŵ
        Debug.Log("�г� �ı� ���� �̺�Ʈ�� �߻���Ŵ");
        OnPanelDestructionResponsed?.Invoke(mapPinInfo);
    }

    // ���� ������ �ʱ�ȭ
    public void SetSensorData(SensorData sensorData)
    {
        Sensor_Data = sensorData;
    }
}
