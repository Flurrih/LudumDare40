using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ingredient", menuName = "Custom/Ingredient", order = 0)]
public class Ingredient : ScriptableObject
{
    public string name;
    public int id;
    public Sprite image;
}
