using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //���ӿ����� ��� �ؽ�Ʈ
    public Text timeText; //���� �ð� ǥ���� �ؽ�Ʈ
    public Text recordText; //�ְ� ��� ǥ���� �ؽ�Ʈ

    private float surviveTime; //�����ð�
    private bool isGameover; //���ӿ��� ����
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        //���ӿ����� �ƴ� ����
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime; //�����ð� ǥ��
        }
        else
        {
            //���ӿ��� ���¿��� RŰ�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        //���ӿ��� �Ǹ� �ؽ�Ʈ Ȱ��ȭ
        gameoverText.SetActive(true);

        //BestTime Ű�� ����� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���� �̹� ����� �ְ� ��Ϻ��� ���ٸ�
        if(surviveTime > bestTime)
        {
            //��� �ٲٰ� BestTimeŰ�� ����
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", surviveTime);
        }

        recordText.text = "Best Time : " + (int)bestTime;
    }
}
