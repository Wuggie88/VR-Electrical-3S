using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitScript : MonoBehaviour
{

    //the current points of the circuit
    public float doorpoints = 4;


    public GameObject battery;
    public GameObject R1;
    public GameObject R2;
    public GameObject R3 = null;
    public float batteryValue;
    public float R1Value;
    public float R2Value;
    public float R3Value;
    public enum PuzzleType { Serie, Parallel }

    public PuzzleType puzzleType;

    //the target needed for the circuit to be correctly solved
    public float target = 5;


    public float[] r;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setupComponent()
    {
        if (puzzleType == PuzzleType.Serie)
        {
            StartCoroutine(calculateThisBitch());
        }
        
        else if (puzzleType == PuzzleType.Parallel)
        {
            StartCoroutine(calculateParallelBitch());
        }


    }

    IEnumerator calculateThisBitch()
    {
        batteryValue = battery.GetComponent<Snapping>().values;
        R1Value = R1.GetComponent<Snapping>().values;
        R2Value = R2.GetComponent<Snapping>().values;
        R3Value = R3.GetComponent<Snapping>().values;

        yield return new WaitForEndOfFrame();

        doorpoints = batteryValue / (R1Value + R2Value + R3Value);

        Debug.Log("Serial door points: " + doorpoints);
    }

    IEnumerator calculateParallelBitch()
    {
        batteryValue = battery.GetComponent<Snapping>().values;
        R1Value = R1.GetComponent<Snapping>().values;
        R2Value = R2.GetComponent<Snapping>().values;

        yield return new WaitForEndOfFrame();

        doorpoints = batteryValue * (1 / R1Value + 1 / R2Value);

        Debug.Log("Parallel door points: " + doorpoints);
    }
    /*
     * Use this as the Circuit script
     * The door button will set the requirement as "target" so set that in your prefab for what the solution should be.
     * Use doorpoints, as the current points obtained (This is the thing that should be updated by batteries and resistors being put in the circuit)
     */

    
}