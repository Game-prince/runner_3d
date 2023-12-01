using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // updating the position of ground
        transform.position = player.transform.position + new Vector3(-player.transform.position.x, 0, 45);
    }
}
