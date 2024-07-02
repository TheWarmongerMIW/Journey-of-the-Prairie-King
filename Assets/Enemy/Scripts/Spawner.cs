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
    public Instruction instruction;
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
        //Gates[0] = GameObject.FindGameObjectWithTag("Gate1").transform;
    }
    private void Awake()
    {
        //spawn = StartCoroutine(Spawn());
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timercontroller>();
        instruction = GameObject.Find("Instruction").GetComponent<Instruction>();   
        SpawnRate = Random.Range(2, 10);
        GateList = new List<Transform>(Gates);
    }
    private void Update()
    {
        if (instruction == null)
        {
            if (timer.TimeRemaining <= 0) return;
            if (GateList.Count <= 0) GateList = new List<Transform>(Gates);
            SpawnRate -= Time.deltaTime;
            if (SpawnRate <= 0)
            {
                Spawn();
                SpawnRate = Random.Range(3, 10);
            }
        }
    }
    private void Spawn()
    {
        if (GateList.Count == 0) return;    
        int take = Random.Range(1, Mathf.Min(7,GateList.Count));
        for (int i = 0; i < take; ++i)
        {
            int randomGate = Random.Range(0, GateList.Count);
            Instantiate(ZombiePrefab, GateList[randomGate].position, GateList[randomGate].rotation);
            //Debug.Log(GateList[randomGate].name);//
            GateList.RemoveAt(randomGate);
        }
    }
}
