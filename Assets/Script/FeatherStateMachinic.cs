using UnityEngine;

public class FeatherStateMachanic : MonoBehaviour
{
    public enum FeatherState { Idle, Floating, Broken }
    public FeatherState currentState = FeatherState.Idle;

    private Rigidbody2D rb;
    private int collisionCount = 0;
    public int maxCollisions = 15;
    public float rotationSpeed = 200f;

    private CollisionUI collisionUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionUI = FindObjectOfType<CollisionUI>();
    }

    void Update()
    {
        if (currentState == FeatherState.Floating)
        {
            rb.angularVelocity = rotationSpeed;

            if (rb.linearVelocity.magnitude < 0.1f)
            {
                currentState = FeatherState.Idle;
                rb.angularVelocity = 0;
            }
        }
    }

    public void ApplyWind(Vector2 force)
    {
        if (currentState != FeatherState.Broken)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
            currentState = FeatherState.Floating;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collisionCount++;
            collisionUI.UpdateCollisionText();

            if (collisionCount >= maxCollisions)
            {
                currentState = FeatherState.Broken;
                rb.angularVelocity = 0;
                GameManager.Instance.GameOver(false);
            }
        }
    }

    public int GetCollisionCount()
    {
        return collisionCount;
    }
}