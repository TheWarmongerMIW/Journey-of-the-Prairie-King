using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Sprite sprite;
    [SerializeField] private Image itemimage; 

    public void AddItem(Sprite sprite)
    {
        this.sprite = sprite;
        itemimage.sprite = sprite;    
    }
    public void OnUsed()
    {
        itemimage.sprite = null;    
    }
}
