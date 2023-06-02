using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //���� ������
    public float spawnRateMin = 0.5f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //�ִ� ���� �ֱ�

    private Transform target; //�߻��� ���
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn; //�ֱ� �������� ���� �ð�
    void Start()
    {
        timeAfterSpawn = 0f; //�ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //���� �ֱ� ���� ����
        //PlayerController�� ���� ������Ʈ�� �˻��� transform�� ������� ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime; //�ð� ����

        //������ �ð��� ���� �ֱ⺸�� ũ��
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f; //����

            //bullet ������ Spawner�� ��ġ�� ���⿡�� ����
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //���� ���� �÷��̾ ���ϵ��� ȸ��
            bullet.transform.LookAt(target);
            //���� �ֱ� �ٽ� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
