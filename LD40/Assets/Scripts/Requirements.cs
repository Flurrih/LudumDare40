using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "requirements", menuName = "Custom/Requirements", order = 0)]
public class Requirements : ScriptableObject
{

    public Ingredient[] ingredients;
}
