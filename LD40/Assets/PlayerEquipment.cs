using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour {

    public enum FoodComponent
    {
        Mustard,
        Ketchup,
        Sausage,
        Roll,
        None
    }

    public FoodComponent carryingComponent = FoodComponent.None;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(carryingComponent);
	}
}
