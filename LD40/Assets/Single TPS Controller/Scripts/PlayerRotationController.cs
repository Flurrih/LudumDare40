
using UnityEngine;
using System.Collections;

public class PlayerRotationController : MonoBehaviour {

    private float vertical;
    private float rotationVelocity = 4.0f;
    void Start ()
    {
        vertical = transform.eulerAngles.x;
    }
	
	void Update ()
    {
        var mouseVertical = Input.GetAxis("Mouse Y");
        vertical = (vertical - rotationVelocity * mouseVertical) % 360f;
        vertical = Mathf.Clamp(vertical, -30, 60);
        transform.localRotation = Quaternion.AngleAxis(vertical, Vector3.right);
    }
}
