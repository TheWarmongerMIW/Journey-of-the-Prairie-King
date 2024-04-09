using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ZombiePrefab;
    [SerializeField] private float SpawnRate = 10;
    [SerializeField] private bool CanSpawn = true;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Spawn());
    }
private IEnumerator Spawn ()
    {
        WaitForSeconds wait = new WaitForSeconds(Random.Range(3,SpawnRate)); 
        while (CanSpawn)
        {
            yield return wait;
            Instantiate(ZombiePrefab, transform.position, transform.rotation);
        }
    }
}
