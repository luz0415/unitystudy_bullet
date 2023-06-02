using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //원본 프리팹
    public float spawnRateMin = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3f; //최대 생성 주기

    private Transform target; //발사할 대상
    private float spawnRate; //생성 주기
    private float timeAfterSpawn; //최근 생성에서 지난 시간
    void Start()
    {
        timeAfterSpawn = 0f; //초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //생성 주기 랜덤 지정
        //PlayerController를 가진 오브젝트를 검색해 transform을 대상으로 지정
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime; //시간 갱신

        //누적된 시간이 생성 주기보다 크면
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f; //리셋

            //bullet 복제본 Spawner의 위치와 방향에서 생성
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //정면 방향 플레이어를 향하도록 회전
            bullet.transform.LookAt(target);
            //생성 주기 다시 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
