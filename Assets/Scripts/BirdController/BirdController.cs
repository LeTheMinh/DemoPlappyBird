using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    public static BirdController instance;
    public float bounceForce;      // do nay
    private Rigidbody2D myBody;
    private Animator anim;



    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;         // am thanh

    private bool isAlive;
    private bool didFlap;

    private GameObject spawner;

    public float flag = 0;
    public int score = 0;
    
    void Awake()// ham khoi tao
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _MakeInstance();
        spawner = GameObject.Find("Spawner Pipe");
    }

    void _MakeInstance()//dong bo hoa cac scripts
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMoveMent();
    }
    void _BirdMoveMent()
    {
        if(isAlive == true)
        {
            if(didFlap == true)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }
        // xet cac van toc
        if(myBody.velocity.y > 0)
        {
            float corner = 0;
            corner = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, corner);// dai luong xoay tra ve ...
        }
        else if(myBody.velocity.y==0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (myBody.velocity.y < 0)
        {
            float corner = 0;
            corner = Mathf.Lerp(0, -90, -myBody.velocity.y / 7); // phep toan noi suy a,b theo t
            transform.rotation = Quaternion.Euler(0, 0, corner);
        }
    }
    public void FlapButton()
    {
        didFlap = true;
    }
    // xu ly va cham
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag =="PipeHolder")

        {
            score++;
            if(GamePlayController.instance != null)
            {
                GamePlayController.instance._SetScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")           
        {
            if (isAlive == true)
            {
                isAlive = false;

                flag = 1;
                Destroy(spawner);
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");
            }
            if(GamePlayController.instance != null)
            {
                GamePlayController.instance._BirdDiedShowPanel(score);
            }
        }
    }
}
