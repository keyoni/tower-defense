using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
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
    public static event Action<Enemy> OnEnemyDied;

    public static event Action<Enemy> GoalReached;
    // NOTE! This code should work for any speed value (large or small)

    private Animator _animator;

    private static readonly int Speed = Animator.StringToHash("Speed");

    //-----------------------------------------------------------------------------
    void Start()
    {
        _animator = GetComponent<Animator>(); 
        // todo #2
        //   Place our enemy at the starting waypoint
        transform.position = waypointList[0].position;
        targetWaypointIndex = 1;
        OnEnemyDied += EnemyDeath;
        GoalReached += EnemyWin;
        
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        Vector3 targetPosition = waypointList[targetWaypointIndex].position;
        Vector3 movementDir = (targetPosition - transform.position).normalized;

        //Vector3 newPosition = transform.position;
        transform.position += movementDir * speed * Time.deltaTime;
        _animator.SetFloat(Speed, transform.position.magnitude);
        // todo #4 Check if destination reaches or passed and change target
        float dist = Vector3.Distance(targetPosition, transform.position);
        if (dist < 0.5f)
        {
            targetWaypointIndex++;
           transform.LookAt(waypointList[targetWaypointIndex],-Vector3.forward);
           // Debug.Log("New Position");
        }
        
        if (targetWaypointIndex >= waypointList.Count -1)
        {
            GoalReached?.Invoke(this);
        }
    }

    //-----------------------------------------------------------------------------
   

   public void Hit()
    {
        health--;
        if (health == 0)
        {
            Debug.Log("I died!");
            OnEnemyDied?.Invoke(this);
        }
    }

   private void EnemyDeath(Enemy enemy)
   {
       Destroy(enemy.gameObject,5f);
   }

   private void EnemyWin(Enemy enemy)
   {
       Destroy(enemy.gameObject);
   }
   
   
}
