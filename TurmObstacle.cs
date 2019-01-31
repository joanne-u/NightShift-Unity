using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurmObstacle : MonoBehaviour
{

    public int damage = 1;
    public float currentBergSpeed;
    public float accelerationBergTime = 30;
    private float minBergSpeed;

    public GameObject effect;

    private Shake shake;

    //Berg Sound
    public GameObject bergCollision;

    void Start()
    {
        //Screen Shake
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        currentBergSpeed = GameObject.Find("/bergSpawner").GetComponent<BergSpawner>().bergSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentBergSpeed * Time.deltaTime);
    }


    //Kollision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Sound
            Instantiate(bergCollision, transform.position, Quaternion.identity);

            //Camera Shake (duration, magnitude)
            shake.CamShake();

            other.GetComponent<Player>().health -= damage;
        }
    }
}