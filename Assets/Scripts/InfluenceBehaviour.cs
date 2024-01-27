using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InfluenceBehaviour
{
    private float maxValue = 1;
    private float minValue = 0;
    [SerializeField] public float value;

    public void ModifyValue(float difference)
    {
        value += difference;
        if (value <= minValue) GameOverDeficit();
        if (value >= maxValue) GameOverExcess();
    }

    public abstract void GameOverDeficit();
    public abstract void GameOverExcess();
}
