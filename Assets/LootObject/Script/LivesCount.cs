using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesCount : MonoBehaviour
{
    private TextMeshProUGUI livescount;

    private void Start()
    {
        livescount = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateLivesCount(LootManager lootmanager)
    {
        livescount.text = lootmanager.NumberofLives.ToString();
    }
}
