using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuyComponent(PlayerEquipment.FoodComponent food)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>().carryingComponent = food;
    }
}
