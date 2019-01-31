
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullObstacle : MonoBehaviour
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

//    //Polygon Collider entsprechend Sprite-Animation verändern
//    public bool iStrigger;
//    public PhysicsMaterial2D _material;

//    private SpriteRenderer spriteRenderer;
//    private List<Sprite> spritesList;
//    private Dictionary<int, PolygonCollider2D> spriteColliders;
//    private bool _processing;

//    private int _frame;
//    public int Frame
//    {
//        get { return _frame; }
//        set
//        {
//            if (value != _frame)
//            {
//                if (value > -1)
//                {
//                    spriteColliders[_frame].enabled = false;
//                    _frame = value;
//                    spriteColliders[_frame].enabled = true;
//                }
//                else
//                {
//                    _processing = true;
//                    StartCoroutine(AddSpriteCollider(spriteRenderer.sprite));
//                }
//            }
//        }
//    }

//    private IEnumerator AddSpriteCollider(Sprite sprite)
//    {
//        spritesList.Add(sprite);
//        int index = spritesList.IndexOf(sprite);
//        PolygonCollider2D spriteCollider = gameObject.AddComponent<PolygonCollider2D>();
//        spriteCollider.isTrigger = iStrigger;
//        spriteCollider.sharedMaterial = _material;
//        spriteColliders.Add(index, spriteCollider);
//        yield return new WaitForEndOfFrame();
//        Frame = index;
//        _processing = false;
//    }

//    private void OnEnable()
//    {
//        spriteColliders[Frame].enabled = true;
//    }

//    private void OnDisable()
//    {
//        spriteColliders[Frame].enabled = false;
//    }

//    private void Awake()
//    {
//        spriteRenderer = this.GetComponent<SpriteRenderer>();

//        spritesList = new List<Sprite>();

//        spriteColliders = new Dictionary<int, PolygonCollider2D>();

//        Frame = spritesList.IndexOf(spriteRenderer.sprite);
//    }

//    private void LateUpdate()
//    {
//        if (!_processing)
//            Frame = spritesList.IndexOf(spriteRenderer.sprite);
//    }
//}
