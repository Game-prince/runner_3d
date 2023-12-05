using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public TMP_Text scoreText, coinText;
    private int score = 0, coins = 0;
    private float gravityValue = -9.81f;
    private float jumpHeight = 1f;
    private float playerSpeed = 2f;
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    private bool isRunning = false;


    Animator animator;
    CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if W is pressed
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
        }

        // if jump is pressed
        bool isGrounded = controller.isGrounded;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("isJumping", true);
        }


        isRunning = animator.GetBool("isRunning");
    }

    void FixedUpdate()
    {
        // if the player has landed
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            animator.SetBool("isJumping", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        Vector3 move = new((isRunning && horizontal == 0) ? 0 : horizontal < 0 ? -3 : 3, 0, isRunning ? 10 : 0);
        controller.Move(playerSpeed * Time.deltaTime * move);



        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetBool("isJumping", true);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // dead logic
        bool isDead = animator.GetBool("isDead");
        if (isDead)
        {
            animator.SetBool("isRunning", false);
            playerVelocity = Vector3.zero;
        }


        // updating score
        score = (int)transform.position.z;
        scoreText.text = "Score : " + score.ToString();

        // updating coins
        coinText.text = "Coins : " + coins.ToString();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("isDead", true);
        }
        else if (other.gameObject.CompareTag("Collectable"))
        {
            coins++;
            Destroy(other.gameObject);
        }
    }

}
