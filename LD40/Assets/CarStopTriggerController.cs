using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStopTriggerController : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            other.gameObject.GetComponent<CarController>().StoppedOnTrafficLight = true;
        }
    }
}
