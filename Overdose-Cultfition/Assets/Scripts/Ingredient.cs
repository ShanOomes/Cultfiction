using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ingredient", menuName = "ingredient")]
public class Ingredient : ScriptableObject
{
    public new string name;

    public float deathChanceMin;
    public float deathChanceMax;

    public float multiplier;

    public GameObject placeholder;
}
