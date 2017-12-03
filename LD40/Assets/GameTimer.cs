using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    float gameTime = 0;
    public Text time;
    public bool CanCount = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(CanCount)
            gameTime += Time.deltaTime;

        
        time.text = System.Math.Round(gameTime, 1).ToString();
	}
}
