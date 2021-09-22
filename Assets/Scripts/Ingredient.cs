using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum intendedFor { Stove, Microwave, Mixer, All };
public abstract class Ingredient
{
    private string name;

    private float deathChanceMin;
    private float deathChanceMax;

    private float failureRate;
    private float multiplier;

    private GameObject placeholder;

    private intendedFor intended;

    //Properties
    public string Name { get { return this.name; } set { this.name  = value; } }
    public float Weight { get { return this.weight; } set { this.weight = value; } }
}
