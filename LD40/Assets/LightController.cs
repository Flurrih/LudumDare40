using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public Material RedMat, GreenMat;

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
            this.GetComponent<Renderer>().sharedMaterial = RedMat;
        }

        if(color == Color.green)
        {
            Light = LightType.Green;
            this.GetComponent<Renderer>().sharedMaterial = GreenMat;
        }
    }
}
