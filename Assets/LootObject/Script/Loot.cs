using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public Sprite lootsprite;
    public PolygonCollider2D collider;
    public string lootname;
    public int dropchance; 

    public Loot(string lootname, int dropchance)
    {
        this.lootname = lootname;
        this.dropchance = dropchance;
    }
}
