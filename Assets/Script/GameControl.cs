using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public Text scoreText;

    private int score = 0;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown("Escape"))
        {
            Application.Quit();
        }
    }

    public void BirdScored()
    {
        Debug.Log("111111111111111111111");
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score:" + score.ToString();
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
