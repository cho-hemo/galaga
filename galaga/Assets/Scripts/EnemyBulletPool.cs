using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBulletPool : MonoBehaviour
{
    public static EnemyBulletPool Instance { get; private set; }

    private const string BULLET_PREFAB_FILE_NAME = "EnemyBullet";
    private const int MAX_BULLET_COUNT = 50;
    private List<GameObject> poolList = new List<GameObject>();
    private GameObject bulletPrefab;
    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePool();
    }

    public void ActiveBullet(Vector3 pos)
    {
        if (currentIndex >= poolList.Count)
        {
            if (poolList[0].activeInHierarchy)
            {
                GameObject bullet = Instantiate(bulletPrefab, gameObject.transform);
                bullet.transform.position = pos;
                poolList.Add(bullet);

                return;
            }
            else
            {
                currentIndex = 0;
            }
        }

        poolList[currentIndex].transform.position = pos;
        poolList[currentIndex].SetActive(true);
        ++currentIndex;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void InitializePool()
    {
        bulletPrefab = Resources.Load($"Prefabs/{BULLET_PREFAB_FILE_NAME}") as GameObject;
        if (bulletPrefab == null)
            Debug.LogError("Bullet ���� �ε� ����");

        for (int i = 0; i < MAX_BULLET_COUNT; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform);
            poolList.Add(bullet);

            poolList[i].SetActive(false);
        }
    }
}
