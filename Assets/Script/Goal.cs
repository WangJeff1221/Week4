using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Feather"))
        {
            GameManager.Instance.GameOver(true);
        }
    }
}
