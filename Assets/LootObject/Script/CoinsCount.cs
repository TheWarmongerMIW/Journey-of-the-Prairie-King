using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCount : MonoBehaviour
{
    private TextMeshProUGUI coincount;
    private void Start()
    {
        coincount = GetComponent<TextMeshProUGUI>();    
    }
    public void UpdateCoinText(LootManager lootmanager)
    {
        coincount.text = lootmanager.NumberofCoins.ToString();
    }
}
