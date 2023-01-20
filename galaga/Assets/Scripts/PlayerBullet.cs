using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{ // �Ѿ�

    private Rigidbody PbulletRigidbody;
    public float speed = 30f;
    public GameObject PlayerLotion;

    float timer = 0;
    float cooltime = 3;

    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        PbulletRigidbody = GetComponent<Rigidbody>();

        // ������ٵ��� �ӵ� = ��* ���ǵ�
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
