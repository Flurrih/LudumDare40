using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCarPaint : MonoBehaviour {

    public List<Material> CarPaint;
    public GameObject Car;
	// Use this for initialization
	void Start () {
        var mats = Car.GetComponent<Renderer>().materials;
        mats[0] = CarPaint[Random.Range(0, CarPaint.Count)];
        Car.GetComponent<Renderer>().materials = mats;
	}
}
