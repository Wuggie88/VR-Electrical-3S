using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wire Object", menuName = "Inventory System/Items/Wire")]

public class WireObject : ItemObject
{
    
    public void Awake()
    {
        type = ItemType.Wire;
    }
}
