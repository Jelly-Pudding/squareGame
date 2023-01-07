using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSquare : MonoBehaviour
{
    public string Position = "bottomLeft";
    void Start()
    {
        // Get the camera object
        Camera camera = Camera.main;

        // Calculate the position of the bottom left corner of the camera in world space

        // Get the width and height of the object's sprite in pixels
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float width = spriteRenderer.sprite.bounds.size.x * Mathf.Abs(transform.localScale.x);
        float height = spriteRenderer.sprite.bounds.size.y * Mathf.Abs(transform.localScale.y);

        Vector3 squarePosition = camera.ViewportToWorldPoint(Vector3.zero);
        if (Position == "bottomLeft")
        {
            squarePosition = camera.ViewportToWorldPoint(Vector3.zero);
            squarePosition.x += width / 2;
            squarePosition.y += height / 2;
        } else if (Position == "topRight")
        {
            squarePosition = camera.ViewportToWorldPoint(Vector3.one);
            squarePosition.x -= width / 2;
            squarePosition.y -= height / 2;
        } else if (Position == "bottomRight")
        {
            squarePosition = camera.ViewportToWorldPoint(Vector3.right);
            squarePosition.x -= width / 2;
            squarePosition.y += height / 2;
        } else if (Position == "topLeft")
        {
            squarePosition = camera.ViewportToWorldPoint(Vector3.up);
            squarePosition.x += width / 2;
            squarePosition.y -= height / 2;
        }

        // Preserve the object's current z position
        squarePosition.z = transform.position.z;

        // Set the position of the object to the bottom left corner of the camera
        transform.position = squarePosition;
    }
}