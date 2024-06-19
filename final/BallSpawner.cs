using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; //구슬 프리팹
    public float spawnInterval = 2f; //구슬생성 간격 (초)
    public float minX = -10f; // 구슬이 생성될 수 있는 최소 X 좌표
    public float maxX = 10f; // 구슬이 생성될 수 있는 최대 X 좌표 
    public float spawnHeight = 10f; // 구슬이 생성될 Y 좌표 


    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    private IEnumerator SpawnBalls()
    {
        while (true) 
        {
            SpawnBall();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void  SpawnBall()
    {
        float spawnX  = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(spawnX, spawnHeight, 0);
        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    }
}
