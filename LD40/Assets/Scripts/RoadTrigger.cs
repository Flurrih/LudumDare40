using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("PoliceEffect").GetComponent<PoliceEffectController>().IsBeingChasedByCops = true;
        }
    }
}
