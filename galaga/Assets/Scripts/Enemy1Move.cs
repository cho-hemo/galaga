using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    public GameObject player;
    private Vector3 EnemyPos;
    private bool EnemyMoveEnd;
    private bool EnemyMove2End;
    private bool EnemyShowEnd;
    private bool EnemyEnd;
    private float runningTime = 0;
    private Vector2 newPos = new Vector2();
    private Vector2 playerPos = new Vector2();
    void Start()
    {
        transform.position = new Vector3(0, 8, 0);
        EnemyPos = new Vector3(-3.44f, 3.44f, 0);
        EnemyMoveEnd = false;
    }
    // Update is called once per frame
    void Update()
    {
            if (!EnemyMoveEnd)
            {
                transform.position =
                Vector3.MoveTowards(transform.position, EnemyPos, 5*Time.deltaTime);
                if (transform.position.Equals(EnemyPos))
                {
                    EnemyMoveEnd = true;
                    EnemyMove2End = false;
                    runningTime = 0;
                    float x = -3.44f * Mathf.Cos(runningTime);
                    float y = -3.44f * Mathf.Sin(runningTime);
                    EnemyPos = new Vector2(x, y+2);
                }

            }
            else if (!EnemyMove2End)
            {
                transform.position =
                Vector3.MoveTowards(transform.position, EnemyPos, 5*Time.deltaTime);
                if (transform.position.Equals(EnemyPos))
                {
                    EnemyMove2End = true;
                    EnemyShowEnd = false;
                    runningTime = 0;
                }
            }
            else if (!EnemyShowEnd)
            {
                runningTime += Time.deltaTime * 3;
                float x = -3.44f * Mathf.Cos(runningTime);
                float y = -3.44f * Mathf.Sin(runningTime);
                EnemyPos = new Vector2(x, y+2);
                transform.position = EnemyPos;
                if (runningTime >= 6.88f)
                {
                    EnemyShowEnd = true;
                    EnemyPos = new Vector2(player.transform.position.x,player.transform.position.y-10);
                }
            }
            if(EnemyMoveEnd&&EnemyMove2End&&EnemyShowEnd)
            {
                transform.position =
                Vector3.MoveTowards(transform.position, EnemyPos, 10*Time.deltaTime);
            }
    }
}
