using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollController : MonoBehaviour {

    public GameObject Ragdoll;
    public GameObject Player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            Player.SetActive(false);
            Ragdoll.SetActive(true);
        }
    }
}
