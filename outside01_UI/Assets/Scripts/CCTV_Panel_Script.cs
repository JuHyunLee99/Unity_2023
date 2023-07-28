using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class CCTV_Panel_Script : MonoBehaviour
{
    public static CCTV_Panel_Script Instance;   // 패널 스크립트 클래스 자체를 저장할 정적 변수  
    // 오. 클래스에 바로 접근 가능하네. 그럼 객체 하나만으로 다 공유해 쓸 수 있네? 이 용도가 맞나?
    // 이렇게 하면 하나의 인스턴스를 통해 클래스의 변수와 기능에 접근할 수 있으며, 중복 생성을 피하고 일관된 상태를 유지할 수 있음.
    [NonSerialized]
    public string cctvURL;

    [SerializeField]
    private GameObject cctvPanel;    // cctv패널 오브젝트


    private void Awake()    // 씬 시작전에, 스트립트가 게임 오브젝트에 추가될때 호출되는, 초기화 작업에 사용되는 함수.
    {
        Instance = this;    // cctv패널 스크립트 인스턴스를 설정
        cctvPanel.SetActive(false); // 패널을 비활성화
    }

    public void ShowCCTVPanel(string cctvURL)
    {
        this.cctvURL = cctvURL;
        // 패널 활성화
        cctvPanel.SetActive(true);
        Debug.Log(this.cctvURL);
    }

    public void CloseCCTVPanel()
    {
        // 패널을 닫을 때 호출할 함수
        cctvPanel.SetActive(false);
        this.cctvURL = null;
    }
}
