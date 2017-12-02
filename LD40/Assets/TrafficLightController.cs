using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour {

    public GameObject PlayerLight1, PlayerLight2;
    public GameObject CarLight1, CarLight2;
    public float TrafficDuration = 2.0f;
    float trafficCounter = 0f;

    public enum TrafficLightPriority
    {
        Player,
        Car
    }

    public TrafficLightPriority trafficPriority = TrafficLightPriority.Car;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        trafficCounter += Time.deltaTime;

        if(trafficCounter >= TrafficDuration)
        {
            if(trafficPriority == TrafficLightPriority.Player)
            {
                trafficPriority = TrafficLightPriority.Car;
                CarLight1.GetComponent<LightController>().SetLight(Color.green);
                CarLight2.GetComponent<LightController>().SetLight(Color.green);
                PlayerLight1.GetComponent<LightController>().SetLight(Color.red);
                PlayerLight2.GetComponent<LightController>().SetLight(Color.red);
            }
            else if(trafficPriority == TrafficLightPriority.Car)
            {
                trafficPriority = TrafficLightPriority.Player;
                CarLight1.GetComponent<LightController>().SetLight(Color.red);
                CarLight2.GetComponent<LightController>().SetLight(Color.red);
                PlayerLight1.GetComponent<LightController>().SetLight(Color.green);
                PlayerLight2.GetComponent<LightController>().SetLight(Color.green);
            }

            trafficCounter = 0f;
        }
	}
}
