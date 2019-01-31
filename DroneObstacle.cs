
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneObstacle : MonoBehaviour
{

    public int damage = 1;

    public float currentSpeed;
    float maxSpeed = 20f;
    public GameObject player;
    public float accelerationTime = 30;
    private float minSpeed;
    private float time;

    private void Start()
    {
        currentSpeed = GameObject.Find("/Spawner").GetComponent<Spawner>().cloudSpeed;
        minSpeed = currentSpeed;
        time = 0;
    }

    public GameObject effect;

    public GameObject wolkeCollision;


    private void Update()
    {
        //Speed erhöhen
        currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);

        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        time += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Kollision
        if (other.CompareTag("Player"))
        {
            //Sound
            Instantiate(wolkeCollision, transform.position, Quaternion.identity);

            Instantiate(effect, transform.position, Quaternion.identity);

            other.GetComponent<Player>().health -= damage;

            Destroy(gameObject);
        }

    }
}
