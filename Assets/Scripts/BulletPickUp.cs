using UnityEngine;

public class BulletPickup : MonoBehaviour
{
    public float hoverHeight = 0.5f; // Maximum height of the hover
    public float hoverSpeed = 1.0f; // Speed of the hover
    public float spinSpeed = 150.0f; // Speed of the spinning

    private Vector3 startPosition;

    void Start()
    {
        
        // Store the initial position of the object
        startPosition = transform.position;
    }

    void Update()
    {
       
        // Calculate the new Y position for hovering
        float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        // Update the object's position with the new Y value
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Rotate the object around its up axis (Y-axis)
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}