using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private static bool _GameOver = false;
    private GameObject _UI = default;
    private GameObject _GameOverText = default;
    private GameObject _Player = default;

    private const string UI_NAME = "UI";
    private const string GAME_OVER_TEXT = "GameOverText";
    private const string SCENE_NAME = "MainScene";
    private const string PLAYER_NAME = "Player";

    // Start is called before the first frame update
    void Start()
    {
        _UI = GioleFunc.GetRootObj(UI_NAME);
        _GameOverText = GioleFunc.FindChildObj(_UI, GAME_OVER_TEXT);
        _Player = GioleFunc.GetRootObj(PLAYER_NAME);
        // Debug.Log(_GameOverText); //확인 완료
    }

    // Update is called once per frame
    void Update()
    {
        if (_GameOver)
        {
            _GameOverText.SetActive(true);
            _Player.SetActive(false);

            if (Input.GetKeyDown(KeyCode.R))
            {
                _GameOver = false;
                GioleFunc.LoadScene(SCENE_NAME);
                
            }   // if: R키를 누르면 재시작
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GioleFunc.QuitThisGame();
            }   // Q 키를 누르면 종료


        }
    }

    public static void EndGame()
    {
        _GameOver = true;
    }

    // public void EndGame()
    // {
    //     isGameOver = true;
    //     // gameOverText.SetActive(true);
    //     gameOverText.transform.localScale = Vector3.one;

    //     // BestTime 키로 저장된 이전까지의 최고 기록 가져오기
    //     float bestTime = PlayerPrefs.GetFloat(BEST_TIME_RECORD);

    //     // 이전까지의 치고 기록보다 현재 생존 시간이 더 긴 경우
    //     if (bestTime < surviveTime)
    //     {
    //         bestTime = surviveTime;
    //         PlayerPrefs.SetFloat(BEST_TIME_RECORD, bestTime);
    //     }       // if: 현재 surviveTime 이 bestTime보다 클 경우 저장 

    //     // 최고 기록을 텍스트에 갱신한다.
    //     GioleFunc.SetTmpText(bestRecordTextObj, 
    //     $"Best Time : {Mathf.FloorToInt(bestTime)}");
    //     // bestRecordText.text = $"Best Time : {Mathf.FloorToInt(bestTime)}";
    // }       // EndGame()
}
