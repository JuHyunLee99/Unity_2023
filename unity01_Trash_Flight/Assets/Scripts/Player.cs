using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]    // Inspector���� ���� ���� �� �ֵ��� ����
    private float moveSpeed;    // Inspector�� Move Spped�� ����

    // Update is called once per frame
    void Update()
    {

        //float horizontalInput = Input.GetAxisRaw("Horizontal"); // Ű���� ����Ű ��, ��
        //float verticalInpt = Input.GetAxisRaw("Vertical");  // Ű���� ����Ű ��,�Ʒ�
        //Vector3 moveTo = new Vector3(horizontalInput, 0f 0f);
        //transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Ű����� ����
        //Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        //if (Input.GetKey(KeyCode.LeftArrow) )
        //{
        //    transform.position -= moveTo;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow) ) 
        //{
        //    transform.position += moveTo;
        //}

        // ���콺�� ����  // �浹���� �����ϰԵ�(LeftWall , RightWall)
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ġ ��ǥ ����Ƽ ȯ���̶� ���� ����
        //Debug.Log(mousePos); // ���콺 ��ǥ ��ġ �˷���
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f); // ���밪, �ּҰ�, �ִ밪
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);   // x�� ���콺 ��ġ�� ���� ����, y,z�� �״�� ����




    }
}
