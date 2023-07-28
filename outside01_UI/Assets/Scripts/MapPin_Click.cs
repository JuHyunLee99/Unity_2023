using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPin_Click : MonoBehaviour
{
    [SerializeField]
    private string cctvURL; // url�ּ�
    private void OnMouseDown()  // Ŭ�� �̺�Ʈ
    {
        // UI ���� �ִ� �г� ��ũ��Ʈ �ν��Ͻ��� ����Ͽ� �г��� ǥ���մϴ�.
        if (CCTV_Panel_Script.Instance != null)
        {
            CCTV_Panel_Script.Instance.ShowCCTVPanel(cctvURL);
        }
        Debug.Log("MapPin is clicked");
    }
}
