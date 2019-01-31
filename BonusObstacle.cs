using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObstacle : MonoBehaviour
{

    public float currentBonusSpeed;
    public float accelerationBonusTime = 20;
    private float minBonusSpeed;

    //mehrere Collisions verhindern
    private bool hasCollided = false;

    public float speed;
    public float fallSpeed = 80.0f;

    //Bonus Sound
    public GameObject bonusCollision;

    private void Start()
    {
        currentBonusSpeed = GameObject.Find("/BonusSpawner").GetComponent<BonusSpawner>().bonusSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentBonusSpeed * Time.deltaTime);
    }

    //Kollision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasCollided)
        {
            //Sound
            Instantiate(bonusCollision, transform.position, Quaternion.identity);

            //Rigidbody.Dynamic hinzufügen
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            //Score + 1
            ScoreManager.scoreCount += 1;
            hasCollided = true;
        }
    }
}