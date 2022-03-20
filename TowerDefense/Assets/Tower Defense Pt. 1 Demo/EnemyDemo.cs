using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    public int health = 3;
    public float speed = 3f;
    public int coins = 3;

    public List<Transform> waypointList;

    private int targetWaypointIndex;
    // todo #1 set up properties
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death
    public static event Action<EnemyDemo> OnEnemyDied;
    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        //   Place our enemy at the starting waypoint
        transform.position = waypointList[0].position;
        targetWaypointIndex = 1;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        Vector3 targetPosition = waypointList[targetWaypointIndex].position;
        Vector3 movementDir = (targetPosition - transform.position).normalized;

        //Vector3 newPosition = transform.position;
        transform.position += movementDir * speed * Time.deltaTime;
        // todo #4 Check if destination reaches or passed and change target
        Debug.Log($"target :{targetPosition}");
        Debug.Log($"transform :{transform.position}");
        if (transform.position == targetPosition)
        {
            targetWaypointIndex++;
            Debug.Log("New Position");
        }
        
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
    }
}
