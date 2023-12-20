using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGenerator : MonoBehaviour
{
    public Powerup[] powerups;
    private readonly int interval = 2;
    private float currentTime = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime > interval)
        {
            currentTime = 0;
            instantiateRandom();
        }
    }

    void instantiate(string name)
    {

    }

    void instantiateRandom()
    {
        int index = Random.Range(0, powerups.Length);
        powerups[index].instantiate(new Vector3(0, 0, 0));
    }
}
