using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametersShowController : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    private void OnGUI()
    {
        text.text = string.Format("Fat {0:##0}%\nEnergy {1:##0}%", playerHealth.weight * 100, playerHealth.energy * 100);
    }


}
