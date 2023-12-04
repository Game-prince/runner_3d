using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // updating the position of ground
        transform.position = new Vector3(0, 0, player.position.z + 45);
    }
}
