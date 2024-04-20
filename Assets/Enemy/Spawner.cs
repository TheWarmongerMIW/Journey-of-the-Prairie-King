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
    [SerializeField] private float SpawnRate;
    [SerializeField] private Transform[] Gates;
    [SerializeField] private List<Transform> GateList = new List<Transform>();   
    //private Transform randomGate;
    public Timercontroller timer;
    //private int RandomAmount;
    //public Transform Gate1;
    //public Transform Gate2; 
    //public Transform Gate3;
    //private Coroutine spawn;
    //[SerializeField] bool CanSpawn = true;
    /* private float SpawnRate = 13;
     [SerializeField] private bool CanSpawn;
     public bool IsSpawned = false;*/
    //[SerializeField] private float MaxSpawnTime;
    //[SerializeField] private float MinSpawnTime;
    //public float TimeTillSpawn;
    // Start is called before the first frame update
    private void Start()
    {
        Gates[0] = GameObject.FindGameObjectWithTag("Gate1").transform;
    }
    private void Awake()
    {
        //spawn = StartCoroutine(Spawn());
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timercontroller>();
        SpawnRate = Random.Range(2, 10);
        GateList = new List<Transform>(Gates);
    }
    private void Update()
    {
        if (GateList.Count <= 0)
        {
            for (var i = 0; i < Gates.Length; i++)
            {
                GateList = new List<Transform>(Gates);
            }
            //GateList = new List<Transform>(Gates);
        }
        SpawnRate -= Time.deltaTime;
        if (SpawnRate <= 0)
        {
            Spawn();
            SpawnRate = Random.Range(2, 10);
        }
        //if (timer.TimeRemaining <= 0)
        //{
            //StopCoroutine(spawn);
        //}
        /*TimeTillSpawn = TimeTillSpawn - Time.deltaTime;
        if (TimeTillSpawn <= 0)
        {
            Instantiate(ZombiePrefab, transform.position, transform.rotation);
            SetTimeTillSpawn();    
        }*/
    }
    private void Spawn()
    {
        for (int i = 0; i < Random.Range(1, GateList.Count); i++)
        {
            int randomGate = Random.Range(0, GateList.Count);
            Instantiate(ZombiePrefab, Gates[randomGate].position, Gates[randomGate].rotation);
            GateList.RemoveAt(randomGate);
        }
    }
    //}
    /*private IEnumerator Spawn ()
    {
        WaitForSeconds wait = new WaitForSeconds(Random.Range(1,9));
        while (CanSpawn)
        {
            yield return wait;
            Debug.Log(wait);
            Transform RandomGate = Gate[Random.Range(0,Gate.Length)];   
            Instantiate (ZombiePrefab, RandomGate.position, transform.rotation);   
            //for (var i = 0; i < Random.Range(0, 3); i++)
            /*{
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
    }*/
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
