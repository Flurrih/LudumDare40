using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodShopController : MonoBehaviour
{
    private Food food;

    private Requirements requirements;

    public PlayerController movement;
    public PlayerRotationController rotate;
    public Text enterText;
    public Text eatText;
    public GameObject hud;

    public GameObject neededItems;

    public GameObject itemRef;

    public float showTime;
    private float timer;

    public PlayerEquipment playerEquipment;
    public PlayerHealth playerHealth;

    private EnterFoodShopController foodShop;

    private bool canEat;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void InitFood(Food food, Requirements req, EnterFoodShopController foodShop)
    {
        this.food = food;
        this.requirements = req;
        this.foodShop = foodShop;
    }

    void OnEnable()
    {
        CanEat();
        if (canEat)
        {
            playerHealth.Eat(food, foodShop);
            audioSource.Play();
            foodShop.ResetTimer();
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
            SetRequirementsView();
            hud.SetActive(false);
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
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            movement.enabled = true;
            rotate.enabled = true;
            enterText.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            hud.SetActive(true);
        }
    }

    private void CanEat()
    {
        canEat = true;

        if (playerEquipment.GetIngredientsIds().Count < requirements.GetIngredientsIds().Count)
        {
            canEat = false;
            return;
        }

        for (int i = 0; i < requirements.GetIngredientsIds().Count; i++)
        {
            if (!playerEquipment.GetIngredientsIds().Contains(requirements.GetIngredientsIds()[i]))
            {
                canEat = false;
                break;
            }
        }
    }

    private void SetRequirementsView()
    {
        for (int i = 0; i < neededItems.transform.childCount; i++)
        {
            Destroy(neededItems.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < requirements.ingredients.Length; i++)
        {
            GameObject go = Instantiate(itemRef, neededItems.transform);
            go.GetComponent<ShopItemSelector>().ingredient = requirements.ingredients[i];

            Color c = go.GetComponent<Image>().color;
            c.a = playerEquipment.GetIngredientsIds().Contains(requirements.ingredients[i].id) ? 0.5f : 1.0f;
            go.GetComponent<Image>().color = c;
        }
    }
}
