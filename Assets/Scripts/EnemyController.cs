using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float minSpeed = 0.5f;   // The minimum speed of the enemy
    [SerializeField] float maxSpeed = 2f;   // The maximum speed of the enemy

    private int currentWaypoint = 0;    // The index of the current waypoint
    private float progress = 0.0f;      // The progress between the current and next waypoint
    public Transform[] waypoints;      // The path for the enemy to follow
    private float speed;

    private void Start()
    {
        // Retrieve the Waypoint transforms from the scene
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint")
            .Select(x => x.transform)
            .ToArray();

        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        if (waypoints != null && currentWaypoint < waypoints.Length - 1)
        {
            // Calculate the distance and direction to the next waypoint
            Vector3 direction = waypoints[currentWaypoint + 1].position - waypoints[currentWaypoint].position;
            float distance = direction.magnitude;

            // Calculate the position of the enemy based on the progress
            Vector3 position = Vector3.Lerp(waypoints[currentWaypoint].position, waypoints[currentWaypoint + 1].position, progress);

            // Move the enemy towards the next waypoint
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

            // Update the progress based on the distance to the next waypoint
            progress += speed * Time.deltaTime / distance;

            // If the enemy has reached the next waypoint, move to the next one
            if (progress >= 1.0f)
            {
                currentWaypoint++;
                progress = 0.0f;
            }
        }
    }
}
