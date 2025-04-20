using UnityEngine;
using TMPro;

public class CollisionUI : MonoBehaviour
{
    public TextMeshProUGUI collisionText;
    private FeatherStateMachanic feather; 

    void Start()
    {
        feather = FindObjectOfType<FeatherStateMachanic>(); 
        UpdateCollisionText(); 
    }

    public void UpdateCollisionText()
    {
        if (feather != null)
        {
            collisionText.text = $"Collision Count: {feather.GetCollisionCount()}/{feather.maxCollisions}";
        }
    }
}
