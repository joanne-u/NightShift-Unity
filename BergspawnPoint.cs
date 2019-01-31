using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BergspawnPoint : MonoBehaviour
{

    public GameObject Bergobstacle;

    void Start()
    {
        Instantiate(Bergobstacle, transform.position, Quaternion.identity);
    }
}
