using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(TurnOff());  
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);   
    }
}
