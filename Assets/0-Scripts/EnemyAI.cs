using UnityEngine;

// ENEMY AI CLASS
public class EnemyAI : MonoBehaviour {
    public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.

    public float patrolWaitTime = 1f;                       // The amount of time to wait when the patrol way point is reached.
    public Transform[] patrolWayPoints;                     // An array of transforms for the patrol route.

    private UnityEngine.AI.NavMeshAgent _nav;                               // Reference to the nav mesh agent.
    private float _patrolTimer;                              // A timer for the patrolWaitTime.
    private int _wayPointIndex;                              // A counter for the way point array.

    void Awake() {
        this._nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update() {
        Patrolling();
    }

    void Patrolling() {
        // Set an appropriate speed for the NavMeshAgent.
        this._nav.speed = patrolSpeed;

        // If near the next waypoint or there is no destination...
        if (this._nav.remainingDistance < _nav.stoppingDistance) {
            // ... increment the timer.
            this._patrolTimer += Time.deltaTime;

            // If the timer exceeds the wait time...
            if (this._patrolTimer >= patrolWaitTime) {
                // ... increment the wayPointIndex.
                if (this._wayPointIndex == patrolWayPoints.Length - 1) {
                    this._wayPointIndex = 0;
                } else {
                    this._wayPointIndex++;
                }

                // Reset the timer.
                this._patrolTimer = 0;
            }
        } else {
            // If not near a destination, reset the timer.
            this._patrolTimer = 0;
        }

        // Set the destination to the patrolWayPoint.
        this._nav.destination = patrolWayPoints[this._wayPointIndex].position;
    }
}