using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;

    int lane = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lane > 1)
        {
            transform.position += new Vector3(-2, 0, 0);
            lane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && lane < 3)
        {
            transform.position += new Vector3(2, 0, 0);
            lane++;
        }
    }

    void FixedUpdate()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isJumping = animator.GetBool("isJumping");
        bool isDead = animator.GetBool("isDead");

        if (isRunning)
        {

            transform.position += new Vector3(0, 0, 10 * Time.fixedDeltaTime);

            if (isJumping)
            {
                rb.velocity = new Vector3(0, 10 * Time.fixedDeltaTime, 0);
            }
        }
        else if (isDead)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isRunning", false);
        }
    }

}
