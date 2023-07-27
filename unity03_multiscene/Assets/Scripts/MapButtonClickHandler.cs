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
    // ��ư Ŭ�� �̺�Ʈ ó�� �Լ�
    private void OnMouseDown()
    {
        pinMapName = gameObject.name;
        
        // �г��� ���� ���� Collider�� ��Ȱ��ȭ�Ͽ� Ŭ���� ����
        GetComponent<Collider>().enabled = false;

        Debug.Log("��ư Ŭ�� �̺�Ʈ ó�� �Լ�");
        // �г� ���� ��û�� EventManager�� ���� ����
        EventManager.Instance.RequestPanelCreation(pinMapName, cctvURL);
    }

    // �г��� ������ �� ȣ��Ǵ� �Լ�
    public void OnPanelClosed()
    {
        // �г��� ���� �Ŀ� Collider�� �ٽ� Ȱ��ȭ�Ͽ� Ŭ�� �����ϰ� ��
        GetComponent<Collider>().enabled = true;
    }
}
