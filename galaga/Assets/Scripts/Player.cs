using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player : MonoBehaviour
{ // �÷��̾�
    
    public PlayerBulletPool playerBulletPool; // ����� ������Ʈ Ǯ�� ����

    private Rigidbody playerRigidbody; // ������Ʈ�� �Ҵ�� ������ٵ� �ڵ����� ã�ư�
    public float playerSpeed = 1.0f; // �÷��̾��� ������ �ӵ��� �ʱ�ȭ

    float timer = 0; // ����ӵ� �����ϴ� ����ð� ����
    float cooltime = 0.5f; // �߻�ð� �����ϴ� ����

    
    void Start()
    {

        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>(); // GetComponent<> �� ���� ������Ʈ���� �������� �Լ�

        // <> ��� Ÿ�Կ� ������ �� �ִ� �޼���
    }

    
    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer >= cooltime)
        {
            if (Input.GetKey(KeyCode.Space) == true)
            {
                playerBulletPool.ShootBullet(transform.position);
                // ������Ʈ Ǯ���� �߻��ϴ� �Լ��� ȣ�� ( �� ������Ʈ�� ��ġ���� )

                timer = 0;
            }
        }

        // �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal"); // "Horizontal" ����Ƽ�� �����ϴ� �Է� �̸�

        //float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput* playerSpeed;
        //float zSpeed = zInput* playerSpeed;

        // Vector3 �ӵ��� (xSpeed, 0f, zSpeed)�� ����
        Vector3 newVelocity = new Vector3 (xSpeed, 0f, 0f); // ( x, y, z )
        // ����ü

        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;
        // �÷��̾� ������ٵ� �Ҵ�

    }

    public void Die() 
    {
        //GameObject GameOver = GioleFunc.GetRootObj("UIManager");
        GameOver.EndGame();
        gameObject.SetActive(false);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
    }

}
