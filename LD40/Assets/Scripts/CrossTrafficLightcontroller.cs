using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossTrafficLightcontroller : MonoBehaviour
{

    public TrafficLightController ZebraA1, ZebraA2, ZebraB1, ZebraB2;

    // Use this for initialization
    void Start()
    {
        if (ZebraA1 != null)
            ZebraA1.trafficPriority = TrafficLightController.TrafficLightPriority.Car;
        if (ZebraA2 != null)
            ZebraA2.trafficPriority = TrafficLightController.TrafficLightPriority.Car;

        if (ZebraB1 != null)
            ZebraB1.trafficPriority = TrafficLightController.TrafficLightPriority.Player;
        if (ZebraB2 != null)
            ZebraB2.trafficPriority = TrafficLightController.TrafficLightPriority.Player;
    }

}
