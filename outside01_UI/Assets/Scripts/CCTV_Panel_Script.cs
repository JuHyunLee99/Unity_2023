using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class CCTV_Panel_Script : MonoBehaviour
{
    public static CCTV_Panel_Script Instance;   // �г� ��ũ��Ʈ Ŭ���� ��ü�� ������ ���� ����  
    // ��. Ŭ������ �ٷ� ���� �����ϳ�. �׷� ��ü �ϳ������� �� ������ �� �� �ֳ�? �� �뵵�� �³�?
    // �̷��� �ϸ� �ϳ��� �ν��Ͻ��� ���� Ŭ������ ������ ��ɿ� ������ �� ������, �ߺ� ������ ���ϰ� �ϰ��� ���¸� ������ �� ����.
    [NonSerialized]
    public string cctvURL;

    [SerializeField]
    private GameObject cctvPanel;    // cctv�г� ������Ʈ


    private void Awake()    // �� ��������, ��Ʈ��Ʈ�� ���� ������Ʈ�� �߰��ɶ� ȣ��Ǵ�, �ʱ�ȭ �۾��� ���Ǵ� �Լ�.
    {
        Instance = this;    // cctv�г� ��ũ��Ʈ �ν��Ͻ��� ����
        cctvPanel.SetActive(false); // �г��� ��Ȱ��ȭ
    }

    public void ShowCCTVPanel(string cctvURL)
    {
        this.cctvURL = cctvURL;
        // �г� Ȱ��ȭ
        cctvPanel.SetActive(true);
        Debug.Log(this.cctvURL);
    }

    public void CloseCCTVPanel()
    {
        // �г��� ���� �� ȣ���� �Լ�
        cctvPanel.SetActive(false);
        this.cctvURL = null;
    }
}
