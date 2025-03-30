using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;

    public int levelScore = 5;
    
    public static GameManager instance;

    public TextMeshPro tmp;

    private float timeRemaining = 34;

    private int currentSceneNum = 1;
    void Awake()
    {
        // if instance has not been set yet
        if (instance == null)
        {
            // make this object the instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //I'm a duplicate and I need to die, there can only be one
            Destroy(gameObject);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        tmp.text = "Score:" + score + " Level:" + currentSceneNum + " Time Remaining:" + Mathf.Floor(timeRemaining);
        
        //if the time has run out, go to game over scene
        if (timeRemaining <= 0)
        {
            GameOverScene();
            Debug.Log("You've reached Level: " + currentSceneNum + "With Score" + score);
            Destroy(gameObject);
        }
        
        // If I hit a Certain Score, I advance to the next Level(Scene)
        if (score >= levelScore)
        {
            //increase the levelScore by 50%
            levelScore += levelScore + levelScore / 2;
            ChangeScene();
        }
        
    }

    void ChangeScene()
    {
        currentSceneNum++;
        SceneManager.LoadScene(currentSceneNum);
    }

    void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
