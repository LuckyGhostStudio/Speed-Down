using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms =new List<GameObject>();

    public float spawnTime;           //间隔时间
    private float countTime;          //计时
    private Vector3 spawnPosition;    //生成位置

    void Update()
    {
        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        countTime += Time.deltaTime;

        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-3.5f, 3.5f);       //x坐标随机

        if (countTime >= spawnTime)
        {
            CreatPlatforms();       //生成
            countTime = 0;          
        }
    }

    public void CreatPlatforms()        //生成平台
    {
        int index = Random.Range(0, platforms.Count);     //随机生成编号

        Instantiate(platforms[index], spawnPosition, Quaternion.identity, transform);    //生成平台
    }
}
