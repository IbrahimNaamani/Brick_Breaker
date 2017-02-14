using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{

    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null;

    private GameObject clonePaddle;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        Setup();
    }

    public void Setup()
    {
        //Instantiating the paddle at 0,0,0 with no rotation (Quaternion.identity) casted as a game object
        //Because we're using it as a game object (to destroy it and so on)
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    private void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            //Making things slowmotion
            Time.timeScale = .25f;
            //Calling a function with a delay.
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    private void Reset()
    {
        Time.timeScale = 1f;
        //Reloading the same scene.
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;

        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);

        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    private void SetupPaddle()
    {
        //Instantiating the paddle at 0,0,0 with no rotation (Quaternion.identity) casted as a game object
        //Because we're using it as a game object (to destroy it and so on)
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}
