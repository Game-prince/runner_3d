using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject player;
    private float interval = 2;
    private float currentTime = 0;


    // Update is called once per frame
    void Update()
    {
        float[] positionX = { -2, 0, 2 };
        currentTime += Time.deltaTime;


        // creating obstacles every 2 second
        if (currentTime > interval)
        {
            currentTime = 0;
            Instantiate(obstaclePrefab, new Vector3(positionX[Random.Range(0, 3)], 0.5f, player.transform.position.z + 50), Quaternion.identity);
        }
    }
}
