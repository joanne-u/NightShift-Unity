using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private new AudioSource audio;

    public Quaternion InitialRot;

    //keysEnabled auf true setzen, wenn gameover false
    private bool isKeysEnabled = true;

    void Start()
    {
        //Player in Szene hineinfliegen
        transform.position = new Vector2(-12, 0);

        audio = GetComponent<AudioSource>();
        isKeysEnabled = false;

        InitialRot = Quaternion.Euler(new Vector2(this.transform.localRotation.x, this.transform.localRotation.y));
    }

    private Vector2 targetPos;
    public float Yincrement;
    public float speed;

    public float maxHeight;
    public float minHeight;

    //public float Xincrement;
    //public float maxWidth;
    //public float minWidth;

    public int health = 5;

    public GameObject effect;
    public Text healthDisplay;
    public GameObject gameOver;


    //Kollision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bonus") || other.CompareTag("Berg"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);

        }
    }

    void Update()
    {

        //ab position 0 keys enablen
        if (gameObject.transform.position == new Vector3(0, 0, 0))
        {
            isKeysEnabled = true;
        }

        healthDisplay.text = "HEALTH: " + health.ToString();

        Physics2D.IgnoreLayerCollision(10, 11, false);


        //GameOver
        if (health <= 0)
        {

            audio.mute = true;

            //Collider löschen
            Physics2D.IgnoreLayerCollision(10, 11, true);

            isKeysEnabled = false;

            //rotieren
            transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            //rigidbody dynamic
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            //Panel
            gameOver.SetActive(true);

            //Heli zerstören mit Delay
            Destroy(gameObject, 2.5f);

        }

        //Player zu targetPos bewegen
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (isKeysEnabled)
        {

            //Wenn Up/Down Key oder w/s key und nicht über Rand hinaus, Player nach oben/unten bewegen
            if ((Input.GetKey(KeyCode.UpArrow) && transform.position.y < maxHeight) || (Input.GetKey("w") && transform.position.y < maxHeight))
            {

                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);

                //rotieren
                transform.Rotate(Vector3.forward * 30 * Time.deltaTime);

            }
            else if ((Input.GetKey(KeyCode.DownArrow) && transform.position.y > minHeight) || (Input.GetKey("s") && transform.position.y > minHeight))
            {
                targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
                transform.Rotate(Vector3.back * 30 * Time.deltaTime);
            }
            else
            {
                transform.rotation = InitialRot;
            }

            //if ((Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxWidth) || (Input.GetKey("d") && transform.position.x < maxWidth))
            //{
            //    targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
            //}
            //else if ((Input.GetKey(KeyCode.LeftArrow) && transform.position.x > minWidth) || (Input.GetKey("a") && transform.position.x > minWidth))
            //{
            //    targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
            //}
        }
    }
}
