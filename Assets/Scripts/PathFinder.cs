using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawn enemySpawn;
    WaveConfigSO waveConfigSO;
    List<Transform> wayPoints;
    int wayPointIndex = 0;
    // Start is called before the first frame update

    private void Awake() {
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }
    void Start()
    {
        waveConfigSO = enemySpawn.GetCurrentWave();
        wayPoints = waveConfigSO.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = waveConfigSO.GetMoveSpeed() *Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
