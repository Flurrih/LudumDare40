

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //This variable indicates how is the current state of character.
    private int state;

    //This variable indicates if the player is aiming or not.
    private bool isAiming; 

    //Define the turning speed.
    private float turningSpeed = 4.0f;
    

    private float horizontal;

    private Animator animator;
    private Vector3 screenCenter;
    private CursorLockMode mouseLockMode;
    

    public bool LockControl;

    //Get the camera properties.
    public Camera camera; 

    void Start ()
    {
        Cursor.visible = true;
        screenCenter.x = 0.5f;
        screenCenter.y = 0.5f;
        screenCenter.z = 0f;
        animator = GetComponentInChildren<Animator>();
        state = 0;
        isAiming = false;
        LockControl = false;
        horizontal = transform.eulerAngles.y;
    }

    void Update ()
    {
        FocusRaycast();
        if (LockControl == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Control();
        }
        Move();
        Anim();
        FocusCamera();
    }

    private void Anim()
    {
        animator.SetInteger("Estado", state);
    }

    private void Control()
    {
        /*
        Estado:
        01 = Walking
        02 = Running
        03 = Walking Back
        04 = Walking Right
        05 = Walking Left
        */

        if (Input.GetKeyDown("w"))
        {
            state = 1;
        }
        if (Input.GetKeyUp("w") && state == 1)
        {
            state = 0;
            if (Input.GetKey("s")) { state = 3; }
            if (Input.GetKey("a")) { state = 5; }
            if (Input.GetKey("d")) { state = 4; }
        }
        if (Input.GetKeyUp("w") && state == 2)
        {
            state = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && state == 1)
        {
            state = 2;
            if (isAiming == true)
            {
                isAiming = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && state == 2) { state = 1; }
                
        if (Input.GetKeyDown("s"))
        {
            state = 3;
        }
        if (Input.GetKeyUp("s") && state == 3)
        {
            state = 0;
            if (Input.GetKey("a")) { state = 5; }
            if (Input.GetKey("d")) { state = 4; }
            if (Input.GetKey("w")) { state = 1; }
        }

        if (Input.GetKeyDown("d"))
        {
            state = 4;
        }
        if (Input.GetKeyUp("d") && state == 4)
        {
            state = 0;
            if (Input.GetKey("s")) { state = 3; }
            if (Input.GetKey("a")) { state = 5; }
            if (Input.GetKey("w")) { state = 1; }

        }

        if (Input.GetKeyDown("a"))
        {
            state = 5;
        }
        if (Input.GetKeyUp("a") && state == 5)
        {
            state = 0;
            if (Input.GetKey("s")) { state = 3; }
            if (Input.GetKey("d")) { state = 4; }
            if (Input.GetKey("w")) { state = 1; }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isAiming = true;
            if (state == 2)
            {
                state = 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1)) { isAiming = false; }
    }

    private void FocusCamera()
    {
        if (isAiming == true && camera.fieldOfView > 37)
        {
            camera.fieldOfView = camera.fieldOfView - 65.0f * Time.deltaTime;
        }
        if (isAiming == false && camera.fieldOfView < 60)
        {
            camera.fieldOfView = camera.fieldOfView + 65.0f * Time.deltaTime;
        }
    }

    private void FocusRaycast()
    {
        RaycastHit hitInfo;
        Ray cameraRay = camera.ViewportPointToRay(screenCenter);
    }
    
    private void Move()
    {
        var mouseHorizontal = Input.GetAxis("Mouse X");
        horizontal = (horizontal + turningSpeed * mouseHorizontal) % 360f;
        transform.rotation = Quaternion.AngleAxis(horizontal, Vector3.up);

        if (state == 0) { transform.Translate(0, 0, 0); }
        if (state == 1) { transform.Translate(0, 0, 1.0f * Time.deltaTime); }
        if (state == 2) { transform.Translate(0, 0, 5.0f * Time.deltaTime); }
        if (state == 3) { transform.Translate(0, 0, -1.0f * Time.deltaTime); }
        if (state == 4) { transform.Translate(1.0f * Time.deltaTime, 0, 0); }
        if (state == 5) { transform.Translate(-1.0f * Time.deltaTime, 0, 0); }
    }

    public bool GetIsAiming()
    {
        return isAiming;
    }
}
