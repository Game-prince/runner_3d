using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public int interval = 2;
    public int maxCoins = 10;
    public GameObject coinPrefab;

    private float currentTime = 0;
    public Rigidbody rb;

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        float[] positionX = { -2, 0, 2 };

        if (currentTime > interval)
        {
            currentTime = 0;
            Instantiate(coinPrefab, new Vector3(positionX[Random.Range(0, 2)], 0.5f, rb.position.z + Random.Range(10, 50)), Quaternion.Euler(90, 0, 0));

        }
    }
}
