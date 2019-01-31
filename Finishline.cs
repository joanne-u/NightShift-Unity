using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishline : MonoBehaviour
{
    public float speed;
    float time = 60f;

    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            return;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}




