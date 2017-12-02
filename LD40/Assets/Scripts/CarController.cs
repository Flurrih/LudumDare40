using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float CarSpeed = 3.0f;
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + CarSpeed * Time.deltaTime, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
	}
}
