using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private AudioSource Coin15;
    private AudioController audiocontroller;
    private HealthController healthcontroller;

    private void Start()
    {
        audiocontroller = GameObject.Find("Player").GetComponent<AudioController>();    
        healthcontroller = GameObject.Find("Player").GetComponent<HealthController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Coin15.Play();
            DontDestroyOnLoad(Coin15.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (healthcontroller.Health == 0)
        { 
            StartCoroutine(OnDeath());
        }
    }
    private IEnumerator OnDeath()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
