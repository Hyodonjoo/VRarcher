using UnityEngine;

public class ArrowTarget : MonoBehaviour, IScore
{
    public int scoreValue = 1;
    public bool disableOnHit = true;
    public float reEnableTime = 5f;
    public Transform[] waypoints;
    public float speed = 5f;

    private int currentWaypointIndex = 0;

    public int GetScore()
    {
        return scoreValue;
    }

    void Update()
    {
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (disableOnHit)
        {
            gameObject.SetActive(false);
            Invoke("ReEnable", reEnableTime);
        }
    }

    void ReEnable()
    {
        gameObject.SetActive(true);
    }
}
