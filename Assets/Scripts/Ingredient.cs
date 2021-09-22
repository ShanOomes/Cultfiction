using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum intendedFor { Stove, Microwave, Mixer, All };
[CreateAssetMenu(fileName = "New ingredient", menuName = "ingredient")]
public class Ingredient : ScriptableObject
{
    public new string name;

    public float deathChanceMin;
    public float deathChanceMax;

    public float failureRate;
    public float multiplier;

    public GameObject placeholder;

    public intendedFor intended;

    [HideInInspector]
    public string type;
}
