using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private GameObject _StageTextObj = default;
    private GameObject Enemy1 = default;
    private GameObject Enemy2 = default;
    private GameObject Enemy3 = default;

    private const string UI = "UI";
    private const string STAGE_TEXT = "StageText";
    private int CountEnemy = 0;
    private float playtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject uiObj_ = GioleFunc.GetRootObj(UI);
        _StageTextObj = uiObj_.FindChildObj(STAGE_TEXT);

        CountEnemy = 1;
        playtime = 0;
        Enemy1 = GioleFunc.GetRootObj("Enemy1");
        Enemy2 = GioleFunc.GetRootObj("Enemy2");
        Enemy3 = GioleFunc.GetRootObj("Enemy3");

        // 시작하면 스테이지 1
        // 스테이지 1일 때 10초마다 에너미1 출력
        // 점수가 10000이 되면 스테이지 1은 클리어
        // 스테이지 1이 클리어 상태라면 스테이지 2가 된다
        // 스테이지 2일 때 10초마다 에너미1>에너미2 출력
        // 점수가 20000이 되면 스테이지 2도 클리어
        // 스테이지 2와 1이 클리어 상태라면 스테이지 3이 된다
        // 스테이지 3일 때 10초마다 에너미1>에너미2>에너미3 출력
        // 죽을 때까지 반복
        //StartCoroutine(EnemyMake(Enemy1));

    }
    IEnumerator EnemyMake(GameObject Enemy)
    {
        while(CountEnemy <= 10)
        {
        yield return new WaitForSeconds(0.2f);
        Enemy.FindChildObj($"EnemyContainer ({CountEnemy})").SetActive(true);
        CountEnemy++;
        }
        CountEnemy = 1;
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStage(ref int i)
    {
        StopCoroutine("StageLoof");
        Debug.Log(_StageTextObj.name);
        GioleFunc.SetTmpText(_StageTextObj, $"Stage {i + 1}");
        StartCoroutine(StageWait());
        StartCoroutine(StageLoof());
    }

    IEnumerator StageLoof()
    {
        while(true)
        {
        // 스테이지 1일 때 10초마다 에너미1 출력
            StartCoroutine(EnemyMake(Enemy1));
            yield return new WaitForSeconds(7);
            //if(i >= 1)
            //{
        // 스테이지 2일 때 10초마다 에너미1>에너미2 출력
                StartCoroutine(EnemyMake(Enemy2));
                yield return new WaitForSeconds(7);
            //}
            //if (i >= 2)
            //{
        // 스테이지 3일 때 10초마다 에너미1>에너미2>에너미3 출력
                StartCoroutine(EnemyMake(Enemy3));
                yield return new WaitForSeconds(7);
            //}
        }
    }
    IEnumerator StageWait()
    {
        _StageTextObj.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(3);
        _StageTextObj.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
    }



}
