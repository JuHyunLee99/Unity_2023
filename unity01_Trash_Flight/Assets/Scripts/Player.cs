using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]    // Inspector���� ���� ���� �� �ֵ��� ����
    private float moveSpeed;    // Inspector�� Move Spped�� ����

    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;    // �ٽ� ������ �� �ִ� �ð� ����

    private float lastShotTime = 0f;    // ������ ������ �ð�

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

        if (GameManager.instance.isGameOver == false)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if(Time.time - lastShotTime > shootInterval) 
        {
            // ���� ������Ʈ�� �������
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);  // ��ü, ��ġ, ȸ��
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            GameManager.instance.SetGameOver();
            Destroy(gameObject);    // �÷��Ͼ� ����
        }
        else if (other.gameObject.tag =="Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        weaponIndex += 1;    
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }
}











