using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Kitchenware
{
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
        initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int index = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != null && index <= 10  && StoveOpened() == true)//check is not null, if index doesnt exceed limit of 3, if stove is open
        {
            Ingredient tmp = other.gameObject.GetComponent<IngredientDisplay>().ingredient;
            if (SetIngredient(index, tmp))//cache colliding ingredient into array
            {
                print(GetIngredient(index).name +" Added to the stove");
            }


            other.gameObject.SetActive(false);
            index++;
        }
    }
}
