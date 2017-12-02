﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public ControladorDePersonagem movement;
    public ControleOrbital rotate;

    public Text enterText;

    void OnEnable()
    {
        movement.enabled = false;
        rotate.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        enterText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        movement.enabled = true;
        rotate.enabled = true;
        enterText.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
