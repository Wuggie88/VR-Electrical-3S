using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonScript : MonoBehaviour
{

    public GameObject RDoor;
    public GameObject LDoor;
    public GameObject CircuitBoard;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ButtonPush()
    {
        // opens the doors when button is pushed, if puzzle is solved. (door points 4 is a placeholder and is always true atm)
        if (CircuitBoard.GetComponent<CircuitScript>().doorpoints == 4)
        {
            RDoor.GetComponent<DoorOpeningScript>().doorOpen();
            LDoor.GetComponent<DoorOpeningScript>().doorOpen(); 
        }

        // what happens if the puzzle ain't solved when pushed
        else
        {
            //write whatever we want to happen, if the button is pressed and the puzzle ain't solved. (could be a sound being played)
        }
    }

}
