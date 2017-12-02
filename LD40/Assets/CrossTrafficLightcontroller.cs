using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossTrafficLightcontroller : MonoBehaviour
{

    public GameObject ZebraA1, ZebraA2, ZebraB1, ZebraB2;

    // Use this for initialization
    void Start()
    {
        if (ZebraA1 != null)
            ZebraA1.GetComponent<TrafficLightController>().trafficPriority = TrafficLightController.TrafficLightPriority.Car;
        if (ZebraA2 != null)
            ZebraA2.GetComponent<TrafficLightController>().trafficPriority = TrafficLightController.TrafficLightPriority.Car;
        if (ZebraB1 != null)
            ZebraA1.GetComponent<TrafficLightController>().trafficPriority = TrafficLightController.TrafficLightPriority.Player;
        if (ZebraB2 != null)
            ZebraA2.GetComponent<TrafficLightController>().trafficPriority = TrafficLightController.TrafficLightPriority.Player;
    }

}
