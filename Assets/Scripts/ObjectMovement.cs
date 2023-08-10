using UnityEngine;
using UnityEngine.UI;

public class ObjectMovement : MonoBehaviour
{
    public float detectionRange = 5f;
    public Button moveButton;
    public float angleIncrement = 90f;
  

    private void Start()
    {
        moveButton.onClick.AddListener(MoveObjects);
    }

    private void MoveObjects()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRange);

        foreach (Collider2D collider in hitColliders)
        {
            GameObject objectToMove = collider.gameObject;
            Vector2 directionToCenter = (Vector2)objectToMove.transform.position - (Vector2)transform.position;
            Vector2 rotatedDirection = Quaternion.Euler(0, 0, angleIncrement) * directionToCenter;
            Vector2 newPosition = (Vector2)transform.position + rotatedDirection;
            objectToMove.transform.position = newPosition;
        }
        
    }
}