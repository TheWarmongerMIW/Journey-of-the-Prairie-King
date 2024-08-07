using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    [SerializeField] private Text myText;
    public CurrentState currenstate;

    private void Start()
    {
        CurrentState currentstate = GameObject.Find("LevelState").GetComponent<CurrentState>(); 
    }
    public void LoadCurrentData()
    {
        string dataToKeep = myText.text;
        /*currentstate.Lives = dataToKeep;
        currentstate.Coins = dataToKeep;
        currentstate.Time = dataToKeep;*/
    }
}
