using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임오버때 띄울 텍스트
    public Text timeText; //생존 시간 표시할 텍스트
    public Text recordText; //최고 기록 표시할 텍스트

    private float surviveTime; //생존시간
    private bool isGameover; //게임오버 상태
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        //게임오버가 아닌 동안
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime; //생존시간 표시
        }
        else
        {
            //게임오버 상태에서 R키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        //게임오버 되면 텍스트 활성화
        gameoverText.SetActive(true);

        //BestTime 키로 저장된 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //만약 이번 기록이 최고 기록보다 높다면
        if(surviveTime > bestTime)
        {
            //기록 바꾸고 BestTime키로 저장
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", surviveTime);
        }

        recordText.text = "Best Time : " + (int)bestTime;
    }
}
