using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //탄알 이동속도
    private Rigidbody bulletRigidbody; //탄알 리지드바디

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        //속도 = 앞쪽 방향 * 속력
        bulletRigidbody.velocity = transform.forward * speed;

        //3초후에 파괴
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        //충돌한 오브젝트가 Player 태그일 경우
        if(other.tag == "Player")
        {
            //PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null)
            {
                //PlayerController 컴포넌트의 Die 메소드 실행
                playerController.Die();
            }
        }
    }
}