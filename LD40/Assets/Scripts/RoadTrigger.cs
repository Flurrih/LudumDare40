using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour {

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("PoliceEffect").GetComponent<PoliceEffectController>().IsBeingChasedByCops = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        GameObject.FindGameObjectWithTag("PoliceEffect").GetComponent<PoliceEffectController>().IsBeingChasedByCops = false;

    }
}
