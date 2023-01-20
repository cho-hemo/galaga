using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{ // ������Ʈ Ǯ

    public GameObject[] bulletPool; // ���� ������Ʈ �迭�� ����

    public GameObject PlayerBullet;// �Ѿ�

    public GameObject player; // �÷��̾� ����

    private int bulletNumber = 0; // �Ѿ��� ������ ����


    void Start() // �迭�� ������Ʈ ���
    {
        bulletPool = new GameObject[10]; // �Ѿ��� 10��

        for (int i = 0; i < 10; i++)
        {
            bulletPool[i] = Instantiate(PlayerBullet, gameObject.transform);
            // ���� ( �Ѿ�, �� ������Ʈ. ��ġ )
            bulletPool[i].name = "PlayerBullet_" + i; 
            // ���� �� �̸��� ���ͼ� �˱� ����
            bulletPool[i].SetActive(false); // ������ ����

        }



    }

    private void Update()
    {

    }

    public void ShootBullet(Vector3 playerPosition)
    { // �߻��ϴ� �Լ�

        bulletPool[bulletNumber].transform.position = playerPosition;
        bulletPool[bulletNumber].SetActive(true);
        bulletNumber++;
        if (bulletNumber == 10)
        {
            bulletNumber = 0;
        }
    }
}