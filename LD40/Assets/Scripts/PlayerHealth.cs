using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public SkinnedMeshRenderer[] meshes;

    public float StartWeight, StartPower;

    [HideInInspector]
    public float weight, energy;

    private void Start()
    {
        weight = StartWeight;
        energy = StartPower;
    }

    private void Update()
    {
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].SetBlendShapeWeight(0, weight * 100);
        }
    }

    public void Eat(Food food, EnterFoodShopController foodShopController)
    {
        weight += food.fat;
        energy += food.energy;

        if (weight > 1)
        {
            weight = 1f;
        }
        else if (energy > 1)
        {
            energy = 1f;
        }
        foodShopController.DrawNewRequirements();
        Debug.Log("You ate " + food.name + "\n weight: " + weight + ", energy: " + energy);
    }
}
