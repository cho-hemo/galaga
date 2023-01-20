using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{ // 오브젝트 풀

    public GameObject[] bulletPool; // 게임 오브젝트 배열로 관리

    public GameObject PlayerBullet;// 총알

    public GameObject player; // 플레이어 선언

    private int bulletNumber = 0; // 총알을 관리할 변수


    void Start() // 배열에 오브젝트 담기
    {
        bulletPool = new GameObject[10]; // 총알은 10개

        for (int i = 0; i < 10; i++)
        {
            bulletPool[i] = Instantiate(PlayerBullet, gameObject.transform);
            // 생성 ( 총알, 이 오브젝트. 위치 )
            bulletPool[i].name = "PlayerBullet_" + i; 
            // 생성 시 이름이 나와서 알기 쉬움
            bulletPool[i].SetActive(false); // 사용안함 상태

        }



    }

    private void Update()
    {

    }

    public void ShootBullet(Vector3 playerPosition)
    { // 발사하는 함수

        bulletPool[bulletNumber].transform.position = playerPosition;
        bulletPool[bulletNumber].SetActive(true);
        bulletNumber++;
        if (bulletNumber == 10)
        {
            bulletNumber = 0;
        }
    }
}