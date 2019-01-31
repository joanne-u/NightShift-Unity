
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public int damage = 1;

    public float currentSpeed;
    float maxSpeed = 20f;
    public GameObject player;
    public float accelerationTime;
    private float minSpeed;
    private float time;

    public GameObject effect;
    public GameObject wolkeCollision;

    private void Start()
    {
        currentSpeed = GameObject.Find("/Spawner").GetComponent<Spawner>().cloudSpeed;
        minSpeed = currentSpeed;
        time = 0;
    }

    private void Update()
    {
        //Speed erhöhen
        currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);

        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        time += Time.deltaTime;
    }


    //Kollision
    void OnTriggerEnter2D(Collider2D other)
    {
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
