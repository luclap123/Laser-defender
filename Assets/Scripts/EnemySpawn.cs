using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i),
            currentWave.GetStartingPoint().position,
            Quaternion.identity,
            transform);
        }
    }
}
