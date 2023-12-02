using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject player;
    private GameObject[] obstacles = new GameObject[3];
    private int currentPointer = 0;
    [SerializeField] public float interval = 2;
    private float currentTime = 0;


    // Update is called once per frame
    void Update()
    {
        float[] positionX = { -2, 0, 2 };
        currentTime += Time.deltaTime;


        // removing and creating obstacles which are behind the player
        if (currentTime > interval)
        {
            currentTime = 0;
            Destroy(obstacles[currentPointer]);
            GameObject obstacle = Instantiate(obstaclePrefab, new Vector3(positionX[Random.Range(0, 2)], 0.5f, player.transform.position.z + Random.Range(10, 50)), Quaternion.identity);
            obstacles[currentPointer++] = obstacle;

            currentPointer %= 3;
        }
    }
}
