using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ingredient", menuName = "Custom/Ingredient", order = 0)]
public class Ingredient : ScriptableObject
{
    public new string name;
    public int id;
    public Sprite image;

    public Ingredient(Ingredient other)
    {
        name = other.name;
        id = other.id;
        image = other.image;
    }

    public override bool Equals(object other)
    {
        var ingredient = other as Ingredient;
        if (ingredient != null)
        {
            return id == ingredient.id;
        }
        return false;
    }
}
