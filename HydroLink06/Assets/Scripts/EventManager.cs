using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    // 센서 데이터 클래스의 인스터스를 멤버 변수로 선언
    public SensorData Sensor_Data;

    // 패널 생성 요청 이벤트를 정의
    public event Action<MapPinInfo> OnPanelCreationRequested;
    public event Action<MapPinInfo> OnPanelDestructionResponsed;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("EventManager.Instance 생성");
            Instance = this;
            Sensor_Data = new SensorData();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); // 이 객체가 씬 전환 시 파괴되지 않도록 설정
    }

    // 패널 생성 요청 함수
    public void RequestPanelCreation(MapPinInfo mapPinInfo)
    {
        // 패널 생성 요청 이벤트를 발생시킴
        Debug.Log("패널 생성 요청 이벤트를 발생시킴");
        OnPanelCreationRequested?.Invoke(mapPinInfo);

    }
    // 패널 파괴 응답 함수
    public void ResponsePanelDestruction(MapPinInfo mapPinInfo)
    {
        // 패널 파괴 반응 이벤트를 발생시킴
        Debug.Log("패널 파괴 반응 이벤트를 발생시킴");
        OnPanelDestructionResponsed?.Invoke(mapPinInfo);
    }

    // 센서 데이터 초기화
    public void SetSensorData(SensorData sensorData)
    {
        Sensor_Data = sensorData;
    }
}
