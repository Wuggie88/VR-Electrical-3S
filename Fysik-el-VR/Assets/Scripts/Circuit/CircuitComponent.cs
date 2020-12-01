using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CircuitComponent : MonoBehaviour
{
    [HideInInspector]
    public CircuitComponent leftSegment;
    [HideInInspector]
    public CircuitComponent rightSegment;
    [HideInInspector]
    private List<MeshRenderer> meshesToPaint;

    //Usually only one of these in the scene at a time
    public bool hasBattery;

    //For Resistances (Modstande)
    //public bool isResistance = false
    //public int resistance = 0;

    //I used a red, yellow, and green material
    public Material offMat;
    public Material oneWayMat;
    public Material powerMat;

    //Optional event for receiving/losing power,
    //like opening and closing a door
    public UnityEvent powerEvent;
    public UnityEvent losePowerEvent;

    //Resets every frame, set by pulses
    public bool leftPowered = false;
    public bool rightPowered = false;

    //Does not reset, decided after pulsing finishes
    private bool powered = false;

    //only true during a pulse for checking
    //for loops
    private bool pulsing;

    private void Awake()
    {
        //Register all the meshes I want to paint.
        //I tagged all of them with "Wire"
        meshesToPaint = new List<MeshRenderer>();
        foreach (Transform child in transform)
        {
            if (child.tag == "CircuitPart")
            {
                meshesToPaint.Add(child.gameObject.GetComponent<MeshRenderer>());
            }
        }
        UpdateMat();
    }

    public void Update()
    {
        //Handle events for gaining and losing power.
        if (!powered && leftPowered && rightPowered)
        {
            powered = true;
            powerEvent.Invoke(); //call Resistance Function instead?
        }
        else if (powered && !(leftPowered && rightPowered))
        {
            powered = false;
            losePowerEvent.Invoke();
        }

        //Reset power
        leftPowered = false;
        rightPowered = false;
    }

    //Don't pulse until everything is reset from Update()
    private void LateUpdate()
    {
        //Only segments with batteries start a pulse
        if (hasBattery)
        {
            if (leftSegment != null)
                leftSegment.Pulse(this);
            if (rightSegment != null)
                rightSegment.Pulse(this);
        }
        UpdateMat();
    }

    //Recursive function for deciding connections to batteries
    public void Pulse(CircuitComponent from)
    {
        //If a segment has already been visited in a pulse, it
        //must have looped.
        if (!pulsing)
        {
            pulsing = true;
            if (from == leftSegment && from == rightSegment)
            {
                //Handle edge case of a circuit with only two segments
                leftPowered = true;
                rightPowered = true;
            }
            else if (from == leftSegment)
            {
                leftPowered = true;
                if (rightSegment != null)
                    rightSegment.Pulse(this);
            }
            else if (from == rightSegment)
            {
                rightPowered = true;
                if (leftSegment != null)
                    leftSegment.Pulse(this);
            }
        }
        UpdateMat();
        pulsing = false;
    }

    /*
    public void Resistance() //Maybe return int?
    {
        // The right Resistance / parameters?
        powerEvent.Invoke();
    }
    */

    public void UpdateMat()
    {
        Material mat;
        if (hasBattery)
        {
            //Batteries work a little different. Never red.
            if (leftSegment != null && leftSegment.leftPowered &&
                rightSegment != null && rightSegment.rightPowered)
            {
                mat = powerMat;
            }
            else
            {
                mat = oneWayMat;
            }
        }
        else
        {
            if (leftPowered && rightPowered)
            {
                mat = powerMat;
            }
            else if (leftPowered || rightPowered)
            {
                mat = oneWayMat;
            }
            else
            {
                mat = offMat;
            }
        }

        //Apply the material to every assigned mesh
        foreach (var rend in meshesToPaint)
        {
            rend.material = mat;
        }
    }
}
