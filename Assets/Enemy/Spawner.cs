using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ZombiePrefab;
    private int random;
    private int RandomAmount;
    public Transform Gate1;
    public Transform Gate2; 
    public Transform Gate3;
    public Timercontroller timer;
    Coroutine _Spawn;
    [SerializeField] bool CanSpawn = true;
   /* private float SpawnRate = 13;
    [SerializeField] private bool CanSpawn;
    public bool IsSpawned = false;*/
    //[SerializeField] private float MaxSpawnTime;
    //[SerializeField] private float MinSpawnTime;
    //public float TimeTillSpawn;
    // Start is called before the first frame update
    private void Awake()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timercontroller>();  
        _Spawn = StartCoroutine(Spawn());
    }
    private void Update()
    {
        random = Random.Range(1,8);
        if (timer.TimeRemaining <= 0)
        {
            StopCoroutine(_Spawn);
        }
        /*TimeTillSpawn = TimeTillSpawn - Time.deltaTime;
        if (TimeTillSpawn <= 0)
        {
            Instantiate(ZombiePrefab, transform.position, transform.rotation);
            SetTimeTillSpawn();    
        }*/
    }
    private IEnumerator Spawn ()
    {
        WaitForSeconds wait = new WaitForSeconds(Random.Range(1,10));
        while (CanSpawn)
        {
            yield return wait;
            for (var i = 0; i < Random.Range(0, 4); i++)
            {
                if (random == 1) Instantiate(ZombiePrefab, Gate1.position, Gate1.rotation);
                if (random == 2) Instantiate(ZombiePrefab, Gate2.position, Gate2.rotation);
                if (random == 3) Instantiate(ZombiePrefab, Gate3.position, Gate3.rotation);
                if (random == 4)
                {
                    Instantiate(ZombiePrefab, Gate1.position, Gate1.rotation);
                    Instantiate(ZombiePrefab, Gate2.position, Gate2.rotation);
                }
                if (random == 5)
                {
                    Instantiate(ZombiePrefab, Gate1.position, Gate1.rotation);
                    Instantiate(ZombiePrefab, Gate3.position, Gate3.rotation);
                }
                if (random == 6)
                {
                    Instantiate(ZombiePrefab, Gate2.position, Gate2.rotation);
                    Instantiate(ZombiePrefab, Gate3.position, Gate3.rotation);
                }
                if (random == 7)
                {
                    Instantiate(ZombiePrefab, Gate1.position, Gate1.rotation);
                    Instantiate(ZombiePrefab, Gate2.position, Gate2.rotation);
                    Instantiate(ZombiePrefab, Gate3.position, Gate3.rotation);
                }
            }
         }
    }
    //private void SetTimeTillSpawn()
    //{
        //TimeTillSpawn = Random.Range(MinSpawnTime, MaxSpawnTime);   
    //}
    /*private void FixedUpdate()
    {
        if (Random.Range(0, 2) == 0)
        {
            CanSpawn = false;
        }
        if (Random.Range(0, 2) == 1)
        {
            CanSpawn = true;
        }
    }
    private IEnumerator Spawn ()
    {
        WaitForSeconds wait = new WaitForSeconds(Random.Range(4,SpawnRate));    
        while (CanSpawn)
        {
            yield return new WaitForSeconds(Random.Range(4,SpawnRate));
            Instantiate(ZombiePrefab, transform.position, transform.rotation);
            IsSpawned = true;
        }
    }*/
}
