using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : Kitchenware
{
    public List<Transform> locations = new List<Transform>();

    private int amount = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        maxIngredients = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Action()
    {
        if(AmountOfIngredients() == 1)
        {
            enhanceProduct();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null && kitchenWareOpened() == true)//check is not null, if stove is open
        {
            Ingredient ingredient = other.gameObject.GetComponent<Ingredient>();
            if (ingredient.type.ToString() == "All")
            {
                if (IsMaxFilled())
                {
                    if (SetIngredient(ingredient, locations[AmountOfIngredients()]))//cache colliding ingredient into array
                    {
                        GameManager.instance.displayText(ingredient.Name + " added to the microwave");
                        other.gameObject.SetActive(false);
                    }
                    else
                    {
                        GameManager.instance.displayText(ingredient.Name + "not added, not enough space");
                    }
                }
                else
                {
                    GameManager.instance.displayText(ingredient.Name + "not added, is full!");
                }

            }
            else
            {
                GameManager.instance.displayText(ingredient.Name + ", wrong kitchenware");
            }

        }
    }
}
