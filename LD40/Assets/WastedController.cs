using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class WastedController : MonoBehaviour
{
    public Image GrayImage;
    float timer;

    private void Update()
    {
        GrayImage.enabled = true;
    }
}
