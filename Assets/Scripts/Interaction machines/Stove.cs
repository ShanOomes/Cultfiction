using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Kitchenware
{
    private int volume;

    public GameObject[] arrPlacholders;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        volume = 3;

        initialize(volume);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int index = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != null && StoveOpened() == true)//check is not null, if index doesnt exceed limit of 3, if stove is open
        {
            Ingredient tmp = other.gameObject.GetComponent<IngredientDisplay>().ingredient;
            if (SetIngredient(index, tmp))//cache colliding ingredient into array
            {
                GameManager.instance.displayText(GetIngredient(index).name + " Added to the stove");
                other.gameObject.SetActive(false);
                SetPlaceholder(index, arrPlacholders[index]);
                index++;
            }
        }
    }
}
