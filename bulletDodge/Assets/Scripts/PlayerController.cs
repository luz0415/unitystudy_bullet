using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    void Start()
    {
        //rigidbody �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //������ ������ �Է°���
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ�
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //�ӵ� ����
        Vector3 newVelocity = new Vector3 (xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);

        //GameManager Ÿ���� ������Ʈ�� ã�Ƽ� EndGame() �޼ҵ� ����
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
