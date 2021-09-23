using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { Stove, Microwave, Mixer, All };
public class Ingredient : MonoBehaviour
{
    public string name;

    public float deathChance;

    public float failureRate;
    public float multiplier;

    public GameObject placeholder;

    public Type type;
    //Properties
    public string Name { get { return this.name; } set { this.name  = value; } }
    public float DeathChanceMax { get { return this.deathChance; } }
    public float FailureRate { get { return this.failureRate; } }
    public float Multiplier { get { return this.multiplier; } set { this.multiplier = value; } }
    public GameObject Placeholder { get { return this.placeholder; } set { this.placeholder = value; } }
    public Type Type { get { return this.type; } set { this.type = value; } }

    public Ingredient()
    {
        name = "Default";

        deathChance = 0;

        failureRate = 0;
        multiplier = 1;

        placeholder = null;
        type = Type.All;
    }

    public void Set(string name, float deathChance, float failureRate, float multiplier, GameObject placeholder, Type type)
    {
        this.name = name;

        this.deathChance = deathChance;

        this.failureRate = failureRate;
        this.multiplier = multiplier;

        this.placeholder = placeholder;
        this.type = type;
    }
}
