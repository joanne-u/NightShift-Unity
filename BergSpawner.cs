using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BergSpawner : MonoBehaviour
{

    private float timeBtwBergSpawn;
    public float startTimeBtwBergSpawn;
    public float decreaseBergTime;
    public float minBergTime = 1.5f;

    public float bergSpeed = 3.0f;

    bool isSpawning = false;
    public float minTime;
    public float maxTime;
    public GameObject[] obstacleBergPatterns;


    IEnumerator SpawnObject(int index, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Instantiate(obstacleBergPatterns[index], transform.position, transform.rotation);
        isSpawning = false;
    }

    private void Update()
    {
        if (timeBtwBergSpawn <= 0)
        {

            if (!isSpawning)
            {
                isSpawning = true;
                int enemyIndex = Random.Range(0, obstacleBergPatterns.Length);
                StartCoroutine(SpawnObject(enemyIndex, Random.Range(minTime, maxTime)));
            }

            bergSpeed = Mathf.Min(bergSpeed + .3f, 5.0f);

            timeBtwBergSpawn = startTimeBtwBergSpawn;

            if (startTimeBtwBergSpawn > minBergTime)
            {
                startTimeBtwBergSpawn -= decreaseBergTime;
            }
        }
        else
        {
            timeBtwBergSpawn -= Time.deltaTime;

        }
    }

}
