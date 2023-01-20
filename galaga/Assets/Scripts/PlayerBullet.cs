using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{ // 총알

    private Rigidbody PbulletRigidbody;
    public float speed = 30f;
    public GameObject PlayerLotion;

    float timer = 0;
    float cooltime = 3;

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        PbulletRigidbody = GetComponent<Rigidbody>();

        // 리지드바디의 속도 = 앞* 스피드
        PbulletRigidbody.velocity = transform.right * speed;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooltime)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }

}
