using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private bool menuIsActive;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuIsActive)
            {
                menu.SetActive(true);
                menuIsActive = true;
            }
            else
            {
                menu.SetActive(false);
                menuIsActive = false;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
