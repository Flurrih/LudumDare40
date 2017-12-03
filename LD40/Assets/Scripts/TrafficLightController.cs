using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{

    public GameObject PlayerLight1, PlayerLight2;
    public GameObject CarLight1, CarLight2;
    public GameObject StopTrigger1, StopTrigger2;
    public GameObject StartTrigger1, StartTrigger2;
    public GameObject policetrigger;
    public float TrafficDuration = 2.0f;
    float trafficCounter = 0f;

    public enum TrafficLightPriority
    {
        Player,
        Car
    }

    public TrafficLightPriority trafficPriority = TrafficLightPriority.Car;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        trafficCounter += Time.deltaTime;

        if (trafficCounter >= TrafficDuration)
        {
            if (trafficPriority == TrafficLightPriority.Player)
            {
                trafficPriority = TrafficLightPriority.Car;
                if (CarLight1 != null)
                    CarLight1.GetComponent<LightController>().SetLight(Color.green);
                if (CarLight2 != null)
                    CarLight2.GetComponent<LightController>().SetLight(Color.green);
                if (PlayerLight1 != null)
                    PlayerLight1.GetComponent<LightController>().SetLight(Color.red);
                if (PlayerLight2 != null)
                    PlayerLight2.GetComponent<LightController>().SetLight(Color.red);
                if (StopTrigger1 != null)
                    StopTrigger1.SetActive(false);
                if (StopTrigger2 != null)
                    StopTrigger2.SetActive(false);
                if (StartTrigger1 != null)
                    StartTrigger1.SetActive(true);
                if (StartTrigger2 != null)
                    StartTrigger2.SetActive(true);
                if(policetrigger != null)
                policetrigger.SetActive(true);
            }
            else if (trafficPriority == TrafficLightPriority.Car)
            {
                trafficPriority = TrafficLightPriority.Player;
                if (CarLight1 != null)
                    CarLight1.GetComponent<LightController>().SetLight(Color.red);
                if (CarLight2 != null)
                    CarLight2.GetComponent<LightController>().SetLight(Color.red);
                if (PlayerLight1 != null)
                    PlayerLight1.GetComponent<LightController>().SetLight(Color.green);
                if (PlayerLight2 != null)
                    PlayerLight2.GetComponent<LightController>().SetLight(Color.green);

                if (StopTrigger1 != null)
                    StopTrigger1.SetActive(true);
                if (StopTrigger2 != null)
                    StopTrigger2.SetActive(true);
                if (StartTrigger1 != null)
                    StartTrigger1.SetActive(false);
                if (StartTrigger2 != null)
                    StartTrigger2.SetActive(false);

                if(policetrigger != null)
                policetrigger.SetActive(false);
            }

            trafficCounter = 0f;
        }
    }
}
