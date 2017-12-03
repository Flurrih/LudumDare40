using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public GameObject RedLight, GreenLight;

    public enum LightType
    {
        Green,
        Red
    }

    public LightType Light;

	public void SetLight(Color color)
    {
        if (color == Color.red)
        {
            Light = LightType.Red;
            RedLight.SetActive(true);
            GreenLight.SetActive(false);
        }

        if (color == Color.green)
        {
            Light = LightType.Green;
            RedLight.SetActive(false);
            GreenLight.SetActive(true);
        }
    }
}
