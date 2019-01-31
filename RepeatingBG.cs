using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{

    public float speed;
    public float endX;
    public float startX;
    public float maxSpeed;

    private void Update()
    {
        //Background nach links
        if (speed < maxSpeed)
        {
            speed = Mathf.Min(speed + .0015f);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //zurück zum Start
        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }
}
