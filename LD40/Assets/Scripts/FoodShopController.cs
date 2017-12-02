using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodShopController : MonoBehaviour
{
    public Food food;

    private Requirements requirements;

    public ControladorDePersonagem movement;
    public ControleOrbital rotate;
    public Text enterText;
    public Text eatText;

    public float showTime;
    private float timer;

    public PlayerEquipment playerEquipment;
    public PlayerHealth playerHealth;

    private bool canEat;

    void Awake()
    {
        requirements = food.requirementsPool[Random.Range(0, food.requirementsPool.Length)];
    }

    void OnEnable()
    {
        CanEat(playerEquipment);
        if (canEat)
        {
            playerHealth.Eat(food);
            eatText.text = string.Format("Power +{0:##0}% \nWeight +{1:##0}%", food.energy * 100, food.fat * 100);
            eatText.gameObject.SetActive(true);
            timer = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {
            movement.enabled = false;
            rotate.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            enterText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !canEat)
        {
            gameObject.SetActive(false);
        }

        if (canEat)
        {
            if (timer >= showTime)
            {
                gameObject.SetActive(false);
            }
            timer += Time.deltaTime;
        }
    }

    private void OnDisable()
    {
        if (canEat)
        {
            eatText.gameObject.SetActive(false);
        }
        else
        {
            movement.enabled = true;
            rotate.enabled = true;
            enterText.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void CanEat(PlayerEquipment playerEquipment)
    {
        canEat = true;
        for (int i = 0; i < playerEquipment.GetIngredientsIds().Count; i++)
        {
            if (!requirements.GetIngredientsIds().Contains(playerEquipment.GetIngredientsIds()[i]))
            {
                canEat = false;
                break;
            }
        }
    }
}
