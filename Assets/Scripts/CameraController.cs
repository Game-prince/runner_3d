using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // updating camera position each frame
        transform.position = new Vector3(player.position.x, 2, player.position.z - 5);
    }
}
