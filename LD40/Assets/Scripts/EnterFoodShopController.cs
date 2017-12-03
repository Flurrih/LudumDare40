using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFoodShopController : EnterShopController
{
    public Food food;

    private Requirements requirements;

    public void DrawNewRequirements()
    {
        int index = Random.Range(0, food.requirementsPool.Length);
        Debug.Log("Req index: " + index);
        requirements = food.requirementsPool[index];
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && enterText.enabled)
            {
                if (requirements == null)
                {
                    DrawNewRequirements();
                }
                shop.GetComponent<FoodShopController>().InitFood(food, requirements, this);
                shop.SetActive(true);
            }
        }
    }

}
