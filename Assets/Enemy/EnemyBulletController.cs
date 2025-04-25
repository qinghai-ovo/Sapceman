using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public Vector2 firefoce = new Vector2(0, -150f);
    public void Shoot()
    {
        GetComponent<Rigidbody2D>().AddForce(firefoce);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        //destroy when out of view
        if(transform.position.y < -5.8f)
        {
            Destroy(gameObject);
        }
    }
}
