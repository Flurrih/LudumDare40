

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    //Define the turning speed.
    private float turningSpeed = 4.0f;

    public float verticalMove { get; private set; }

    private float horizontal;

    public Animator animator;

    private CursorLockMode mouseLockMode;

    private Rigidbody rb;

    public float speed;

    //Get the camera properties.
    public Camera camera;

    void Start()
    {
        Cursor.visible = true;
        horizontal = transform.eulerAngles.y;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Control();
        Anim();
    }

    private void Anim()
    {
        animator.SetFloat("Forward", verticalMove);
        animator.SetFloat("Speed", gameObject.GetComponent<PlayerHealth>().weight);
    }

    private void Control()
    {
        verticalMove = Input.GetAxis("Vertical");

        float speedMultiplier = (1 - gameObject.GetComponent<PlayerHealth>().weight) + 0.5f;

        rb.velocity = transform.forward * verticalMove * speed * speedMultiplier;

        var mouseHorizontal = Input.GetAxis("Mouse X");
        horizontal = (horizontal + turningSpeed * mouseHorizontal) % 360f;
        transform.rotation = Quaternion.AngleAxis(horizontal, Vector3.up);
    }
}
