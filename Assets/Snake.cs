using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {


    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();

    int ate = 0;
    float timeScale = 1.5f; 

    public GameObject tailPrefab;
    public Camvas canvas;

    private bool gameovercheck;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Move", 0.15f, 0.15f);
        gameovercheck = false;
        Time.timeScale = timeScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }else
            if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == timeScale)
            {
                Time.timeScale = 0;
                canvas.Paused(true);
            }
            else
            {
                Time.timeScale = timeScale;
                canvas.Paused(false);
            }
        }
        if (gameovercheck)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                canvas.restart();
                Application.LoadLevel(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
     
	}

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);

        if (ate > 0)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate--;
        }
  
        else if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.StartsWith("bonusFood"))
        {
            ate = 5;
            canvas.scoreCanvas(2);
            Destroy(collision.gameObject);
        } 
        else if (collision.name.StartsWith("foodPrefab"))
        {
            ate = 1;
            canvas.scoreCanvas(1);
            Destroy(collision.gameObject);
        }
        else
        {
            canvas.gameOver();
            gameovercheck = true;
        }
    }

}
