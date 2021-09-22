using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDisplay : MonoBehaviour
{
    public Ingredient ingredient;

    // Start is called before the first frame update
    void Start()
    {
        Kitchenware k = GetComponent<Kitchenware>();
        if(k is Microwave)
        {

        }
    }

}
