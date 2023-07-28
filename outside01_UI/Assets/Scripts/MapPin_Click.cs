using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPin_Click : MonoBehaviour
{
    [SerializeField]
    private string cctvURL; // url주소
    private void OnMouseDown()  // 클릭 이벤트
    {
        // UI 씬에 있는 패널 스크립트 인스턴스를 사용하여 패널을 표시합니다.
        if (CCTV_Panel_Script.Instance != null)
        {
            CCTV_Panel_Script.Instance.ShowCCTVPanel(cctvURL);
        }
        Debug.Log("MapPin is clicked");
    }
}
