using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public TMP_Text scoreText, coinText;
    private int score = 0, coins = 0;

    Animator animator;
    Rigidbody rb;

    private int lane = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if left or right arrow key is pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lane > 1)
        {
            transform.position += new Vector3(-2, 0, 0);
            // animator.SetBool("changingLeft", true);
            lane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && lane < 3)
        {
            transform.position += new Vector3(2, 0, 0);
            // animator.SetBool("changingRight", true);
            lane++;
        }


        // if W is pressed
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
        }

        // if jump is pressed
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping", true);
        }
    }

    void FixedUpdate()
    {
        // running logic
        bool isRunning = animator.GetBool("isRunning");
        if (isRunning)
        {
            rb.velocity = new Vector3(0, 0, 500 * Time.fixedDeltaTime);
        }

        // jumping logic
        bool isJumping = animator.GetBool("isJumping");
        if (isJumping)
        {
            // rb.AddForce(new Vector3(0, 100, 0));
            animator.SetBool("isJumping", false);
        }

        // dead logic
        bool isDead = animator.GetBool("isDead");
        if (isDead)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }


        // updating score
        score = (int)rb.position.z;
        scoreText.text = "Score : " + score.ToString();

        // updating coins
        coinText.text = "Coins : " + coins.ToString();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isRunning", false);
        }
        else if (other.gameObject.CompareTag("Collectable"))
        {
            coins++;
            Destroy(other.gameObject);
        }
    }

}
