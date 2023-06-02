using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    void Start()
    {
        //rigidbody 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //수평축 수직축 입력감지
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //속도 지정
        Vector3 newVelocity = new Vector3 (xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //오브젝트 비활성화
        gameObject.SetActive(false);

        //GameManager 타입의 오브젝트를 찾아서 EndGame() 메소드 실행
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
