using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    [SerializeField] private HealthController healthcontroller;
    [SerializeField] private Instruction instruction;
    void Start()
    {
        
    }

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
