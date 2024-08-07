using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    private HealthController healthcontroller;
    private Instruction instruction;
    // Start is called before the first frame update
    void Start()
    {
        healthcontroller = GetComponent<HealthController>();    
        instruction = GameObject.Find("Instruction").GetComponent<Instruction>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (healthcontroller.Health <= 0)
        {
            StartCoroutine(OnDeath());
        }  
    }

    private IEnumerator OnDeath()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
        instruction.gameObject.SetActive(false);    
    }
}
