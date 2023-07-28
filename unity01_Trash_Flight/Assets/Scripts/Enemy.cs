using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private float moveSpeed = 10f;
    private float minY = -7;
    [SerializeField]
    private float hp = 1f;  // 적의 피


    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if(transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)   // 충돌 감지만
    {
       if(other.gameObject.tag == "Weapon")         // 충돌한 대상은 무기
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;    // 적의 피에서 무기의 데이지 빼고
            if(hp < 0)  // 적의 피가 소진되면
            {
                if (gameObject.tag == "Boss")
                {
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject);    // 적 제거
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);  // 적 제거
        }
    }

    //private void OnCollisionEnter2D(Collision2D other)  // 물리적 충돌처리
    //{
       
    //}
}
