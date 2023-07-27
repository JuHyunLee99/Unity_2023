using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class MapButtonClickHandler : MonoBehaviour
{
    [SerializeField]
    string cctvURL;
    string pinMapName;
    // 버튼 클릭 이벤트 처리 함수
    private void OnMouseDown()
    {
        pinMapName = gameObject.name;
        
        // 패널을 열기 전에 Collider를 비활성화하여 클릭을 막음
        GetComponent<Collider>().enabled = false;

        Debug.Log("버튼 클릭 이벤트 처리 함수");
        // 패널 생성 요청을 EventManager를 통해 보냄
        EventManager.Instance.RequestPanelCreation(pinMapName, cctvURL);
    }

    // 패널이 닫혔을 때 호출되는 함수
    public void OnPanelClosed()
    {
        // 패널이 닫힌 후에 Collider를 다시 활성화하여 클릭 가능하게 함
        GetComponent<Collider>().enabled = true;
    }
}
