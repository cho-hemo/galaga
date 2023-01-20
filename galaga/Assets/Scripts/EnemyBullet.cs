
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private const string playerGOName = "Player";
    private const float SPEED = 5.0f;
    private GameObject player;
    private float timer = 0f;
    private float lifeTime = 5.0f;

    private void Awake()
    {
        player = GioleFunc.GetRootObj(playerGOName);//root find �޼���
    }

    private void OnEnable()
    {
        Vector2 diffVector = (player.transform.position - transform.position).normalized;
        float cosTheta = Vector2.Dot(diffVector, Vector2.up);
        float angle = Vector2.Angle(diffVector, Vector2.right);

        transform.rotation = cosTheta >= 0 ? Quaternion.Euler(0, 0, angle) : Quaternion.Euler(0, 0, -angle);

        timer = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.right * SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            gameObject.SetActive(false);
        }
    }
}
