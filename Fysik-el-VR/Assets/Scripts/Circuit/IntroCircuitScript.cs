using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCircuitScript : MonoBehaviour
{
    //the current points of the circuit
    public float doorpoints = 4;


    public GameObject battery;
    public GameObject R1;
    public float batteryValue;
    public float R1Value;
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
            //insert a calculation form for parallel connections
        }


    }

    IEnumerator calculateThisBitch()
    {
        batteryValue = battery.GetComponent<IntroSnapping>().values;
        R1Value = R1.GetComponent<IntroSnapping>().values;

        yield return new WaitForEndOfFrame();

        doorpoints = batteryValue / (R1Value);

        Debug.Log(doorpoints);


    }
}
