using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player : MonoBehaviour
{ // 플레이어
    
    public PlayerBulletPool playerBulletPool; // 사용할 오브젝트 풀을 선언

    private Rigidbody playerRigidbody; // 오브젝트에 할당된 리지드바디를 자동으로 찾아감
    public float playerSpeed = 1.0f; // 플레이어의 움직임 속도를 초기화

    float timer = 0; // 연사속도 조절하는 현재시간 변수
    float cooltime = 0.5f; // 발사시간 조절하는 변수

    
    void Start()
    {

        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>(); // GetComponent<> 는 현재 오브젝트에서 가져오는 함수

        // <> 모든 타입에 대응할 수 있는 메서드
    }

    
    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer >= cooltime)
        {
            if (Input.GetKey(KeyCode.Space) == true)
            {
                playerBulletPool.ShootBullet(transform.position);
                // 오브젝트 풀에서 발사하는 함수를 호출 ( 이 오브젝트의 위치에서 )

                timer = 0;
            }
        }

        // 수평축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal"); // "Horizontal" 유니티가 제공하는 입력 이름

        //float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput* playerSpeed;
        //float zSpeed = zInput* playerSpeed;

        // Vector3 속도를 (xSpeed, 0f, zSpeed)로 생성
        Vector3 newVelocity = new Vector3 (xSpeed, 0f, 0f); // ( x, y, z )
        // 구조체

        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
        // 플레이어 리지드바디에 할당

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
