using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //ź�� �̵��ӵ�
    private Rigidbody bulletRigidbody; //ź�� ������ٵ�

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        //�ӵ� = ���� ���� * �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        //3���Ŀ� �ı�
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        //�浹�� ������Ʈ�� Player �±��� ���
        if(other.tag == "Player")
        {
            //PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null)
            {
                //PlayerController ������Ʈ�� Die �޼ҵ� ����
                playerController.Die();
            }
        }
    }
}