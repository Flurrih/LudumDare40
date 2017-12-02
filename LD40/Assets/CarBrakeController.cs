using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBrakeController : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Car")
        {
            GetComponentInParent<CarController>().Brake();
            GetComponentInParent<CarController>().StoppedOnOtherCar = true;
        }
    }
}
