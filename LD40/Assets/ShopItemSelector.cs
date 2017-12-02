using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemSelector : MonoBehaviour, IPointerClickHandler {
    
    public PlayerEquipment.FoodComponent component;

	public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("Shop").GetComponent<ShopController>().BuyComponent(component);
    }
}
