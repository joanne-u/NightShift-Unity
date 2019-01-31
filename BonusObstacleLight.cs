using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObstacleLight : MonoBehaviour
{
    public float currentBonusSpeed;
    public float accelerationBonusTime = 30;
    private float minBonusSpeed;

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
        //Obstacle auf Player zubewegen
        transform.Translate(Vector2.left * currentBonusSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasCollided)
        {
            //Sound
            Instantiate(bonusCollision, transform.position, Quaternion.identity);

            Destroy(gameObject);

            ScoreManager.scoreCount += 1;
            hasCollided = true;
        }
    }
}