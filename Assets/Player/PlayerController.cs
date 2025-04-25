using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 250;
    public GameObject BulletPrefab;
    public GameObject GameOverui;
    
    
    private Rigidbody2D rb;
    private Animator animator;

    float minX = -2.4f, maxX = 2.4f, minY = -4.47f, maxY = 4.47f;


    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GameOverui.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fire();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();  
        
    }

    void Movement()
    {
        float horizontalmove;
        horizontalmove = Input.GetAxis("Horizontal");
        float verticalmove;
        verticalmove = Input.GetAxis("Vertical");
        float movedirection = Input.GetAxisRaw("Horizontal");

        //player move
        rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, verticalmove * speed * Time.deltaTime);
        animator.SetFloat("Fly", movedirection);
        rb.position =new Vector3(Mathf.Clamp(rb.position.x, minX, maxX), Mathf.Clamp(rb.position.y, minY, maxY),0);
    }

    void fire()
    {
        Debug.Log("fire");
        GameObject Bullet = Instantiate(BulletPrefab);
        Bullet.transform.position = this.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            //gameover
            GameOverui.SetActive(true);
        }
        if(other.gameObject.tag == "EnemyBullet")
        {  
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            GameOverui.SetActive(true);
        }
    }
}
