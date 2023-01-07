using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRightSpawn : MonoBehaviour
{
    void Start()
    {
        // Get the camera object
        Camera camera = Camera.main;

        // Calculate the position of the top right corner of the camera in world space
        Vector3 topRight = camera.ViewportToWorldPoint(Vector3.one);

        // Get the width and height of the object's sprite in pixels
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float width = spriteRenderer.sprite.bounds.size.x * Mathf.Abs(transform.localScale.x);
        float height = spriteRenderer.sprite.bounds.size.y * Mathf.Abs(transform.localScale.y);

        // Offset the position by half the width and height of the object, so it is fully inside the camera
        topRight.x -= width / 2;
        topRight.y -= height / 2;

        // Preserve the object's current z position
        topRight.z = transform.position.z;

        // Set the position of the object to the top right corner of the camera
        transform.position = topRight;
    }
}