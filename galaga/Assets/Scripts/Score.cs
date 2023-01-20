using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 현재 점수를 반영하는 스크립트
public class Score : MonoBehaviour
{
    private GameObject _UI = default;
    private int highScore = 0;
    private int currentScore = 0;
    // private TMP_Text scoreNum = default;
    // private TMP_Text highscoreNum = default;

    private GameObject HighScoreNumObj = default;
    private GameObject CurrentScoreNumObj = default;
    private GameObject uiObj_ = default;
    private GameObject Stage_ = default;
    private Stage Stage = default;
    private bool _StageNext = true;


    private int _StageNum;

    // GameObject Enemy2 = GioleFunc.GetRootObj("Enemy2");
    // GameObject Enemy3 = GioleFunc.GetRootObj("Enemy3");
    //총알과 적을 구현

    void Start()
    {
        // 출력할 점수를 가져오기
        _UI = GioleFunc.GetRootObj("UI");
        HighScoreNumObj = _UI.FindChildObj("HighScoreNum");
        CurrentScoreNumObj = _UI.FindChildObj("CurrentScoreNum");

        // scoreNum = CurrentScoreNumObj.GetComponent<TMP_Text>();
        // highscoreNum = HighScoreNumObj.GetComponent<TMP_Text>();
        uiObj_ = GioleFunc.GetRootObj("UI");
        Stage_ = uiObj_.FindChildObj("StageText");
        Stage = Stage_.GetComponent<Stage>();
        GoNextStage();
    }

    void Update()
    {
        // scoreNum.text = $"{currentScore}";
        GioleFunc.SetTmpText(CurrentScoreNumObj, $"{currentScore}");
        // 현재점수가 최고점수보다 높을 경우 반영
        if (highScore < currentScore)
        {
            highScore = currentScore;
            // highscoreNum.text = $"{highScore}";
            GioleFunc.SetTmpText(HighScoreNumObj, $"{highScore}");

        }
    }

    // 일정 점수가 넘을 시 다음 스테이지로 넘어감

    private void GoNextStage()
    {
        _StageNum = currentScore / 10000;
        if (currentScore == 0)
        {
            Stage.NextStage(ref _StageNum);
        }
        if (currentScore == 10000)
        {
            Stage.NextStage(ref _StageNum);
        }
        if (currentScore == 20000)
        {
            Stage.NextStage(ref _StageNum);
        }
    }

    // 현재점수를 플러스하는 함수
    // 총알이 적과 만나서 OntriggerEnter()가 실행되었을 때
    public void PlusScore()
    {
        currentScore += 100;
        GoNextStage();
    }
}
