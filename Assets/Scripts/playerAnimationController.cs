using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour
{
    public Rigidbody rb;
    Animator animator;
    private bool isRunning = false;
    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Input from the keyboard
        if (Input.GetKey(KeyCode.W))
        {
            isRunning = true;
        }

        isJumping = Input.GetButtonDown("Jump");
    }

    void FixedUpdate()
    {
        // Setting and unsetting isRunning variable
        if (isRunning)
        {
            animator.SetBool("isRunning", true);
            transform.position += new Vector3(0, 0, 10 * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Setting and unsetting isJumping variable
        if (isJumping)
        {
            animator.SetBool("isJumping", true);
            rb.velocity = new Vector3(0, 10 * Time.fixedDeltaTime, 0);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
