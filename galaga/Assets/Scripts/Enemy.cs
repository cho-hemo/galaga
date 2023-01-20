using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyBulletPool enemyBulletPool;
    private Score score;
    private float enemyTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject _UI = GioleFunc.GetRootObj("UIManager");
        score = _UI.GetComponent<Score>();
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        for(int i = 0; i<3; i++)
        {
            yield return new WaitForSeconds(3);
            enemyBulletPool.ActiveBullet(transform.position);
        }
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            enemyTime += Time.deltaTime;
            if(enemyTime>5)
            {
                gameObject.SetActive(false);
                transform.position = new Vector3(0, 8, 0);
                enemyTime = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            Die();
            other.gameObject.SetActive(false);
            score.PlusScore();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
