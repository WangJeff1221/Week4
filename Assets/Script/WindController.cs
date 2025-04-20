using UnityEngine;

public class WindController : MonoBehaviour
{
    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool isDragging = false;
    public float forceMultiplier = 5f; 
    public FeatherStateMachanic feather;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(1) && isDragging) 
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 windForce = (endPoint - startPoint) * forceMultiplier;
            feather.ApplyWind(windForce);
            isDragging = false;
        }
    }
}
