using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawnPoint : MonoBehaviour
{

    public GameObject BonusObstacle;

    void Start()
    {
        Instantiate(BonusObstacle, transform.position, Quaternion.identity);
    }
}
