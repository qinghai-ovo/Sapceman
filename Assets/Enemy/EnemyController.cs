using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public GameObject BulletPrefab;
    public float speed = 3;
    public float movetime = 1.0f;
    public float firetime = 1.0f;

    float mtime;
    float ftime;
    Vector3 movePosition;
    
    float minX = -2.1f, maxX = 2.2f, minY = -0.4f, maxY = 4.37f;

    // Start is called before the first frame update
    void Start()
    {
        movePosition = new Vector3(0.0f, 0.0f, 0.0f);
        
    }

    void FixedUpdate()
    {
        this.mtime += Time.deltaTime;
        if(this.mtime > movetime || this.transform.position == movePosition)
        {
            this.mtime = 0.0f;
            movePosition = RandomPosition(); 
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, movePosition, speed * Time.deltaTime);
        this.ftime += Time.deltaTime;
        if(ftime > firetime)
        {
            this.ftime = 0.0f;
            fire();
        }
    }

    private Vector3 RandomPosition()
    {
        Vector3 ramdompos = new Vector3(Random.Range(minX, maxX+0.1f), Random.Range(minY, maxY+0.1f), 0);
        
        return ramdompos;
    }



    void fire()
    {
        Debug.Log("fire");
        GameObject Bullet = Instantiate(BulletPrefab);
        Bullet.transform.position = this.transform.position;
    }
        

}
