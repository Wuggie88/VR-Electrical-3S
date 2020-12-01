using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitConnector : MonoBehaviour
{
    public bool isLeft;
    CircuitComponent segment; // If it doesn't work, change it to: GameObject

    private void Awake()
    {
        //Expect CircuitSegment script to be on parent.
        segment = transform.parent.GetComponent<CircuitComponent>();
    }

    //Make a connection
    private void OnTriggerEnter(Collider other)
    {
        CircuitConnector otherCon = other.GetComponent<CircuitConnector>();
        if (otherCon != null && otherCon != this)
        {
            //Register connection to segment
            if (isLeft)
            {
                segment.leftSegment = otherCon.segment;
            }
            else
            {
                segment.rightSegment = otherCon.segment;
            }
            //Code for anything else to do during a
            //connection, like instantiate lightning
        }
    }

    //Lose connection
    private void OnTriggerExit(Collider other)
    {

        CircuitConnector otherCon = other.GetComponent<CircuitConnector>();
        if (otherCon != null && otherCon != this)
        {
            //Unregister segment
            if (isLeft && segment.leftSegment == otherCon.segment)
            {
                segment.leftSegment = null;
            }
            if (!isLeft && segment.rightSegment == otherCon.segment)
            {
                segment.rightSegment = null;
            }
        }
    }
}
