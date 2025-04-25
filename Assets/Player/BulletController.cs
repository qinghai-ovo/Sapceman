using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 firefoce = new Vector2(0, 150f);
    public GameObject EnemyDirector;
    public void Shoot()
    {
        GetComponent<Rigidbody2D>().AddForce(firefoce);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //when trigger enemy destroy both
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            EnemyDirector.GetComponent<GameDirector>().kill();
        }

    }

    
    // Start is called before the first frame update
    void Start()
    {
        Shoot();
        EnemyDirector = GameObject.Find("Gamedirector");
    }

    // Update is called once per frame
    void Update()
    {
        //destroy when out of view
        if(transform.position.y > 5.8f)
        {
            Destroy(gameObject);
        }
    }
}
