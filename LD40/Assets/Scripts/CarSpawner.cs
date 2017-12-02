using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Instantiate(Resources.Load("Car"), this.gameObject.transform.position, transform.rotation );
	}
	
}
