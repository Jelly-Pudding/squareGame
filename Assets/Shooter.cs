using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Public field for the ball prefab
    public GameObject ballPrefab;
    public float shootForce = 5f;

    // Update is called once per frame
    void Update()
    {
        // Check for user input
        if (Input.GetMouseButtonDown(0))
        {
            // Shoot a ball
            Shoot();
        }
    }

    // Method to shoot a ball
    void Shoot()
    {
        // Instantiate a new ball at the position of the square object
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the square to the mouse position
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        // Normalize the direction
        direction = direction.normalized;

        // Set the ball's velocity and gravity scale
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = direction * shootForce;
    }
}