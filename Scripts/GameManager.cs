using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject deadPanel;
    public GameObject TouchToStart;
    public GameObject SpawnerEnemy;
   
    public void Awake()
    {
        Time.timeScale = 1.0f;
    }   
    public void GameOver()
    {
       
        StartCoroutine(gameOverCoroutine());
        
    }
   public void GameStart()
    {
        SpawnerEnemy.SetActive(true);
        TouchToStart.SetActive(false);
    }

    IEnumerator gameOverCoroutine()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 1.0f;
        deadPanel.SetActive(true);
        yield break;
    }


    // Start is called before the first frame update
    public void RestartOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
