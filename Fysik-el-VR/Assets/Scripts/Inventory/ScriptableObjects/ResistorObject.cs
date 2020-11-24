using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resistor Object", menuName = "Inventory System/Items/Resistor")]

public class ResistorObject : ItemObject
{
    public int resistorValue;
    public void Awake()
    {
        type = ItemType.Resistor;
    }
}
