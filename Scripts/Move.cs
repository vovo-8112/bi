using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public AudioSource coin;

    public GameObject circle1;
    public GameObject circle2;
   
    public float speed= 2;
  

  
    


    public float min_X = -1.6f, max_X = 1.6f;
    public bool check = false;


    public SpawnerEnemy spawnerEnemy;
    public Enemy enemy;

    public GameObject deadEffectPrefab;
   

    public bool isStart = false;

   
    private void Update()
    {
        WaitToTouch();
        if (!isStart) return;

        if (check) transform.position = Vector3.MoveTowards(transform.position, circle1.transform.position, speed * Time.deltaTime);
        else if(!check) transform.position = Vector3.MoveTowards(transform.position, circle2.transform.position, speed * Time.deltaTime);

        transform.rotation *= Quaternion.Euler(0f, 0f, 2f);
    }
    public void WaitToTouch()
    {
        if (!isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isStart = true;
                GameObject.Find("GameManager").GetComponent<GameManager>().GameStart();
            }
        }
    }

    void AddScore()
    {
        GameObject.Find("GameManager").GetComponent<Score>().addScore(1);
    }
    public void Change()
    {
        check = !check;
    }

    public void Circle2()
    {
        coin.Play();
        circle2.SetActive(false);
        check = true;
        circle1.SetActive(true);
        circle1.transform.position = new Vector3(Random.Range(min_X, max_X), -2.43f, 0f);
        AddScore();
        spawnerEnemy.respawnTime = spawnerEnemy.respawnTime - 0.05f;
        speed = speed + 0.02f;
        enemy.speed = enemy.speed + 0.01f;
    }
    public void Circle1()
    {
        coin.Play();
        circle1.SetActive(false);
        check = false;
        circle2.SetActive(true);
        circle2.transform.position = new Vector3(Random.Range(min_X, max_X), 2.43f, 0f);
        AddScore();
        spawnerEnemy.respawnTime = spawnerEnemy.respawnTime - 0.05f;
        speed = speed + 0.01f;
        enemy.speed = enemy.speed + 0.02f;

    }
    private void Player_Destroy()
    {
        Destroy(Instantiate(deadEffectPrefab, transform.position, Quaternion.identity), 1f);
        Destroy(gameObject);
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        

        //Check to see if the tag on the collider is equal to Circle
        if (collider.gameObject.tag == "Circle2")
        {

            Circle2();
            
        }
         if (collider.gameObject.tag == "Circle1")
        {

            Circle1();
        }
       

        //destroy Player
        if (collider.gameObject.tag == "Enemy") 
        {
            Player_Destroy();
        }
    }
}
