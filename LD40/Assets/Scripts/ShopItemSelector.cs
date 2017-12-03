using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemSelector : MonoBehaviour
{
    public Ingredient ingredient;

    void Start()
    {
        GetComponent<Image>().sprite = ingredient.image;
    }

	public void OnClick ()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>().AddIngredient(ingredient);
    }
}
