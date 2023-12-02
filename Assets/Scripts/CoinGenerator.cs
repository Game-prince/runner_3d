using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public int interval = 2;
    public int maxCoins = 10;
    public GameObject coinPrefab;

    private float currentTime = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if (currentTime > interval)
        {
            currentTime = 0;
            Instantiate(coinPrefab, new Vector3(Random.Range(-2, 2), 0.5f, 0 + Random.Range(10, 50)), Quaternion.identity);

        }
    }
}
