using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Animator animator;

    int lane = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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

}
