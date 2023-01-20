using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Move : MonoBehaviour
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
        EnemyPos = new Vector3(-7, 5, 0);
        EnemyMoveEnd = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (gameObject.activeInHierarchy)
        {
            if (!EnemyMoveEnd)
            {
                transform.position =
                Vector3.MoveTowards(transform.position, EnemyPos, 10*Time.deltaTime);
                if (transform.position.Equals(EnemyPos))
                {
                    EnemyMoveEnd = true;
                    EnemyMove2End = false;
                    EnemyPos = new Vector3(7, 5, 0);
                }

            }
            else if (!EnemyMove2End)
            {
                transform.position =
                Vector3.MoveTowards(transform.position, EnemyPos, 10*Time.deltaTime);
                if (transform.position.Equals(EnemyPos))
                {
                    EnemyMove2End = true;
                    EnemyShowEnd = false;
                    EnemyPos = new Vector3(-7, -0.8f, 0);
                }
            }
            else if (!EnemyShowEnd)
            {
                transform.position =
                Vector3.MoveTowards(transform.position, EnemyPos, 10*Time.deltaTime);
                if (transform.position.Equals(EnemyPos))
                {
                    EnemyMove2End = true;
                    EnemyShowEnd = false;
                    EnemyPos = new Vector3(20, -0.8f, 0);
                }
            }
            if(EnemyMoveEnd&&EnemyMove2End&&EnemyShowEnd)
            {
                transform.position =
                Vector3.MoveTowards(transform.position, EnemyPos, 10*Time.deltaTime);
            }
            
        }
        else
        {
        transform.position = new Vector3(0, 8, 0);
        EnemyPos = new Vector3(-7, 5, 0);
        EnemyMoveEnd = false;
        }
    }
}
