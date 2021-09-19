using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Kitchenware
{
    public GameObject[] arrIngredients;

    public Transform[] holders;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        initialize(3, false);

        if(arrIngredients.Length != 0)
        {
            for (int i = 0; i < arrIngredients.Length; i++)
            {
                int randomIndex = Random.Range(0, arrIngredients.Length);
                Instantiate(arrIngredients[randomIndex].gameObject, holders[i].transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
