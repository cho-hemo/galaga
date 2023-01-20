using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : MonoBehaviour
{
    public GameObject player;
    private Vector3 EnemyPos;
    private bool EnemyShowEnd;
    private bool EnemyEnd;
    private float runningTime = 0;
    private float enemyTime = 0;
    private Vector2 newPos = new Vector2();
    private Vector2 playerPos = new Vector2();
    void Start()
    {
        transform.position = new Vector3(-3, 8, 0);
        EnemyPos = new Vector3(-3.44f, 3.44f, 0);
        EnemyShowEnd = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (gameObject.activeInHierarchy)
        {
            if (!EnemyShowEnd)
            {
                runningTime += Time.deltaTime * 1;
                float x = -5f * Mathf.Sin(runningTime);
                float y = 5f * Mathf.Tan(runningTime);
                EnemyPos = new Vector2(x, y+8);
                transform.position = EnemyPos;
                if (runningTime >= 6.88f)
                {
                    EnemyShowEnd = true;
                    EnemyPos = new Vector2(player.transform.position.x,player.transform.position.y-10);
                }
            }
            if(EnemyShowEnd)
            {
                transform.position =
                Vector3.MoveTowards(transform.position, EnemyPos, 10*Time.deltaTime);
            }
            
        }
        else
        {
        transform.position = new Vector3(-3, 8, 0);
        EnemyPos = new Vector3(-3.44f, 3.44f, 0);
        EnemyShowEnd = false;
        }
    }
}
