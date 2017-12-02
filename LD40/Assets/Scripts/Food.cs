using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "food", menuName = "Custom/Food", order = 0)]
public class Food : ScriptableObject
{
    [Range(0, 1)] public float fat, energy;

    public Requirements[] requirementsPool;

}
