using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]    // Inspector에서 값을 넣을 수 있도록 해줌
    private float moveSpeed;    // Inspector에 Move Spped가 생김

    // Update is called once per frame
    void Update()
    {

        //float horizontalInput = Input.GetAxisRaw("Horizontal"); // 키보드 방향키 좌, 우
        //float verticalInpt = Input.GetAxisRaw("Vertical");  // 키보드 방향키 위,아래
        //Vector3 moveTo = new Vector3(horizontalInput, 0f 0f);
        //transform.position += moveTo * moveSpeed * Time.deltaTime;

        // 키보드로 제어
        //Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        //if (Input.GetKey(KeyCode.LeftArrow) )
        //{
        //    transform.position -= moveTo;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow) ) 
        //{
        //    transform.position += moveTo;
        //}

        // 마우스로 제어  // 충돌영역 무시하게됨(LeftWall , RightWall)
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 위치 좌표 유니티 환경이랑 같게 변경
        //Debug.Log(mousePos); // 마우스 좌표 위치 알려줌
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f); // 보통값, 최소값, 최대값
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);   // x값 마우스 위치에 따라 변경, y,z는 그대로 유지




    }
}
