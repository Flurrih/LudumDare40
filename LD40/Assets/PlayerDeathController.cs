using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour {

    public GameObject WastedObject;
    public GameObject PoliceEffect;
    public GameObject EneFatGUI;

    public void Wasted()
    {
        WastedObject.SetActive(true);
        PoliceEffect.SetActive(false);
        EneFatGUI.SetActive(false);
    }
}
