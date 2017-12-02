using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceEffectController : MonoBehaviour
{

    public GameObject BlueSprite, RedSprite;
     float SwapTime;
    float swapTimer;
    bool status;
    public bool IsBeingChasedByCops;
    public AudioClip policeSyren;
    public AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        status = true;
        IsBeingChasedByCops = false;
        audioSource.clip = policeSyren;
        SwapTime = policeSyren.length / 18;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBeingChasedByCops)
        {
            if (!audioSource.isPlaying && audioSource.clip.isReadyToPlay)
                audioSource.Play();

            swapTimer += Time.deltaTime;

            if (swapTimer >= SwapTime)
            {
                status = !status;
                swapTimer = 0f;
                RedSprite.SetActive(!status);
                BlueSprite.SetActive(status);
            }
        }

    }
}
