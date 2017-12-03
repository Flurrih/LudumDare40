using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliceEffectController : MonoBehaviour
{

    public GameObject BlueSprite, RedSprite;
    float SwapTime;
    float swapTimer;
    bool status;
    public bool IsBeingChasedByCops;
    public AudioClip policeSyren;
    public AudioSource audioSource;

    public Image policeLevelImage;
    public List<Sprite> policeLevelImages;
    float policeChaseTimer = 0;
    public float chaseTime = 2.0f;
    float maxStars = 5;
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
            policeChaseTimer += Time.deltaTime;


            ChangeLevel(policeChaseTimer);
        }
        else
        {
            ChangeLevel(policeChaseTimer);
            if (policeChaseTimer <= 0)
            {
                RedSprite.SetActive(false);
                BlueSprite.SetActive(false);
                policeChaseTimer = 0f;
            }
            else
                policeChaseTimer -= Time.deltaTime;

        }
    }
    void ChangeLevel(float time)
    {
        if (time >= 0 && time < 1 * (chaseTime / maxStars))
        {
            policeLevelImage.sprite = policeLevelImages[0];
        }
        if (time >= 1 * (chaseTime / maxStars) && time < 2 * (chaseTime / maxStars))
        {
            policeLevelImage.sprite = policeLevelImages[1];
        }
        if (time >= 2 * (chaseTime / maxStars) && time < 3 * (chaseTime / maxStars))
        {
            policeLevelImage.sprite = policeLevelImages[2];
        }
        if (time >= 3 * (chaseTime / maxStars) && time < 4 * (chaseTime / maxStars))
        {
            policeLevelImage.sprite = policeLevelImages[3];
        }
        if (time >= 4 * (chaseTime / maxStars) && time < 5 * (chaseTime / maxStars))
        {
            policeLevelImage.sprite = policeLevelImages[4];
        }

        if (time >= 5 * (chaseTime / maxStars) && time < 6 * (chaseTime / maxStars))
        {
            policeLevelImage.sprite = policeLevelImages[5];
        }
        if(time >= 5 * (chaseTime / maxStars))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerDeathController>().Wasted();
        }
    }
}
