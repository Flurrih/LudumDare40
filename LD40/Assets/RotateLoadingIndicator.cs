using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateLoadingIndicator : MonoBehaviour
{

    private float timer = 0;
    private bool isDone = false;

    private AsyncOperation ao;

    void Start()
    {  
        ao = SceneManager.LoadSceneAsync("layout");
        ao.allowSceneActivation = false;
    }

	void Update () {
		transform.rotation = Quaternion.Euler(new Vector3(0,0,transform.rotation.eulerAngles.z - Time.deltaTime * 1000));

	    if (timer >= 10 && !isDone)
	    {
	        ao.allowSceneActivation = true;
	        isDone = true;
	    }
	    timer += Time.deltaTime;
	}
}
