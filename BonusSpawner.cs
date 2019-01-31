using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{

    public GameObject[] bonusObstaclePatterns;

    private float timeBtwBonusSpawn;
    public float startTimeBtwBonusSpawn;
    public float decreaseBonusTime;
    public float minBonusTime;

    public float bonusSpeed = 4.0f;

    private void Update()
    {
        if (timeBtwBonusSpawn <= 0)
        {

            bonusSpeed = Mathf.Min(bonusSpeed + .3f, 9f);

            //randomisieren
            int rand = Random.Range(0, bonusObstaclePatterns.Length);
            Instantiate(bonusObstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwBonusSpawn = startTimeBtwBonusSpawn;
            //Debug.Log(timeBtwBonusSpawn);

            if (startTimeBtwBonusSpawn > minBonusTime)
            {
                startTimeBtwBonusSpawn -= decreaseBonusTime;
            }
        }
        else
        {
            timeBtwBonusSpawn -= Time.deltaTime;
        }
    }

}
