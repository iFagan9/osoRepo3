using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] GameObject spawnGroup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        spawnGroup.SetActive(true);
    }
}
