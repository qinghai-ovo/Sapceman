using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject GameOver;
    public int EnemyCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        GameOver = GameObject.Find("GameOver");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void totitle()
    {
        SceneManager.LoadScene("Gametitle");
    }
    public void kill()
    {
        EnemyCount --;
        if(EnemyCount <= 0)
        {
            GameOver.SetActive(true);
        }
    }

    
}
