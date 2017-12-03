using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFoodShopController : EnterShopController
{
    public Food food;
    public TextMesh cooldownTextMesh;

    public float Cooldown;

    private float timer;

    private Requirements requirements;

    private GameObject player;

    public void DrawNewRequirements()
    {
        int index = Random.Range(0, food.requirementsPool.Length);
        Debug.Log("Req index: " + index);
        requirements = food.requirementsPool[index];
    }

    public void Start()
    {
        timer = Cooldown;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (timer < Cooldown)
        {
            timer += Time.deltaTime;
            if (!cooldownTextMesh.gameObject.activeInHierarchy)
            {
                cooldownTextMesh.gameObject.SetActive(true);
            }
            cooldownTextMesh.text = string.Format("{0:#0.0}s", Cooldown - timer);
            cooldownTextMesh.gameObject.transform.rotation = Quaternion.LookRotation((cooldownTextMesh.gameObject.transform.position - player.transform.position).normalized);
        }
        else
        {
            if (cooldownTextMesh.gameObject.activeInHierarchy)
            {
                cooldownTextMesh.gameObject.SetActive(false);
            }

            if (timer != Cooldown)
            {
                timer = Cooldown;
            }
        }
    }

    public void ResetTimer()
    {
        timer = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && enterText.enabled)
            {
                if (requirements == null)
                {
                    DrawNewRequirements();
                }
                if (timer >= Cooldown)
                {
                    shop.GetComponent<FoodShopController>().InitFood(food, requirements, this);
                    shop.SetActive(true);
                }
            }
        }
    }

}
