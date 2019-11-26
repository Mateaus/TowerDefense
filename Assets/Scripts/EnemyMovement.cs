using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavePointIndex = 0;

    private void Start() {
        target = WayPoints.wayPoints[wavePointIndex];
    }

    private void Update() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            GoToNextWayPoint();
        }
    }

    private void GoToNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.wayPoints.Length - 1)
        {
            return;
        }

        wavePointIndex++;
        target = WayPoints.wayPoints[wavePointIndex];
    }
}
