using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    float brakeTimer = 0f;
    float brakeTime = 1.0f;
    public float CarSpeed = 3.0f;
    public bool StoppedOnTrafficLight = false;
    public bool StoppedOnOtherCar = false;

    public float CarLifeTime = 25.0f;
    // Update is called once per frame
    void FixedUpdate()
    { 
        if (StoppedOnTrafficLight != true)
            this.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.rotation * new Vector3(CarSpeed, 0f, 0f));
        else
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        CarLifeTime -= Time.deltaTime;
        if (CarLifeTime <= 0)
            GameObject.Destroy(this.gameObject);
	}

    public void Brake()
    {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;


    }
}
