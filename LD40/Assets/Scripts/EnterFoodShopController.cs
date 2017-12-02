using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFoodShopController : EnterShopController
{
    public Food food;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && enterText.enabled)
            {
                shop.GetComponent<FoodShopController>().InitFood(food);
                shop.SetActive(true);
            }
        }
    }

}
