using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float StartWeight, StartPower;
    float weight, energy;

    private void Start()
    {
        weight = StartWeight;
        energy = StartPower;
    }

    public void Eat(Food food)
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
    }
}
