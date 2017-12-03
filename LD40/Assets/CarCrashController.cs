using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrashController : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
