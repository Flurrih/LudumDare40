using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStartTriggerController : MonoBehaviour {

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Car")
        {
            other.gameObject.GetComponent<CarController>().StoppedOnTrafficLight = false;
        }
    }
}
