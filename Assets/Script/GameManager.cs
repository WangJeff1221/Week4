using UnityEngine;
using UnityEngine.SceneManagement;  
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int collisionCount = 0;   
    public int maxCollisions = 15;   

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            GameOver(true);  
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collisionCount++;  
            Debug.Log("Collision Count: " + collisionCount);  

            if (collisionCount >= maxCollisions)
            {
                GameOver(false);  
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameOver(bool win)
    {
        SceneManager.LoadScene(win ? "WinScene" : "LossScene"); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }
}
