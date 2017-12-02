using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    private List<Ingredient> ingredients;

    void Start()
    {
        ingredients = new List<Ingredient>();
    }

    void Update()
    {

    }

    public void AddIngredient(Ingredient ingredient)
    {
        bool isInList = false;

        for (int i = 0; i < ingredients.Count; i++)
        {
            if (ingredient.Equals(ingredients[i]))
            {
                isInList = true;
                break;
            }
        }

        if (!isInList)
        {
            ingredients.Add(ingredient);
        }

        foreach (var item in ingredients)
        {
            Debug.Log(item.name);
        }
    }
}
