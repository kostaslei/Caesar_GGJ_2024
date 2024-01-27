using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InfluenceBehaviour
{
    public float value;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void ModifyValue(float difference)
    {
        value += difference;
        if (value == 0) GameOver();
    }

    public abstract void GameOver();
}
