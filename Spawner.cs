using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.6f;

    public float cloudSpeed = 5.0f;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            cloudSpeed = Mathf.Min(cloudSpeed + .1f, 8.5f);

            //randomisieren
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate<GameObject>(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;

            //Spawn-Zeit mit zunehmender Spielzeit abnehmen
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;

        }
    }
}
