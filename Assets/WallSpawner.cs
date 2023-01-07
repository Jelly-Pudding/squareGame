using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallPrefab; // The prefab for the wall game object
    public float wallThickness = 0.1f; // The thickness of the walls
    public float wallDistance = 10f; // The distance of the walls from the camera
    public bool spawnOnStart = true; // Whether to spawn the walls on start

    private Camera mainCamera; // Reference to the main camera

    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnWalls();
        }
    }

    // Spawns the walls around the main camera view
    public void SpawnWalls()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Calculate the screen aspect ratio
        float aspectRatio = mainCamera.aspect;

        // Calculate the size of the walls based on the aspect ratio and the distance from the camera
        float wallHeight = mainCamera.orthographicSize * 2f;
        float wallWidth = wallHeight * aspectRatio;

        // Calculate the positions of the walls
        float left = mainCamera.transform.position.x - wallWidth / 2f - wallThickness / 2f;
        float right = mainCamera.transform.position.x + wallWidth / 2f + wallThickness / 2f;
        float top = mainCamera.transform.position.y + wallHeight / 2f + wallThickness / 2f;
        float bottom = mainCamera.transform.position.y - wallHeight / 2f - wallThickness / 2f;

        // Spawn the walls
        GameObject leftWall = Instantiate(wallPrefab, new Vector3(left, 0f, wallDistance), Quaternion.identity);
        leftWall.transform.localScale = new Vector3(wallThickness, wallHeight + 5, 1f);
        GameObject rightWall = Instantiate(wallPrefab, new Vector3(right, 0f, wallDistance), Quaternion.identity);
        rightWall.transform.localScale = new Vector3(wallThickness, wallHeight + 5, 1f);
        GameObject topWall = Instantiate(wallPrefab, new Vector3(0f, top, wallDistance), Quaternion.identity);
        topWall.transform.localScale = new Vector3(wallWidth + 5, wallThickness, 1f);
        GameObject bottomWall = Instantiate(wallPrefab, new Vector3(0f, bottom, wallDistance), Quaternion.identity);
        bottomWall.transform.localScale = new Vector3(wallWidth + 5, wallThickness, 1f);
    }
}