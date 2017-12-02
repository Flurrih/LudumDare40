using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "requirements", menuName = "Custom/Requirements", order = 0)]
public class Requirements : ScriptableObject
{
    public Ingredient[] ingredients;

    public List<int> GetIngredientsIds()
    {
        List<int> ids = new List<int>();
        for (int i = 0; i < ingredients.Length; i++)
        {
            ids.Add(ingredients[i].id);
        }
        return ids;
    }
}
