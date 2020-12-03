using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    //The Npc name//
    public string name;

    //Sets the size of the sentences text area//
    [TextArea(3,10)]

    //Array to contain the text//
    public string[] sentences;

}
