using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Kitchenware
{
    public List<Transform> locations = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        maxIngredients = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Action()
    {
        if (AmountOfIngredients() >= 2)//are there atleast 2 ingredients in array
        {
            cookingTime();
            GameManager.instance.displayText("Cooking...");
        }
        else
        {
            GameManager.instance.displayText("Not enough ingredients to cook");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != null && kitchenWareOpened() == true)//check is not null, if stove is open
        {
            Ingredient ingredient = other.gameObject.GetComponent<IngredientDisplay>().ingredient;
            if(ingredient.intended.ToString() == "Stove")
            {
                if (IsMaxFilled())
                {
                    if (SetIngredient(ingredient, locations[AmountOfIngredients()]))//cache colliding ingredient into array
                    {
                        GameManager.instance.displayText(ingredient.name + " added to the stove");
                        other.gameObject.SetActive(false);
                    }
                    else
                    {
                        GameManager.instance.displayText(ingredient.name + "not added, not enough space");
                    }
                }
                else
                {
                    GameManager.instance.displayText(ingredient.name + "not added, is full!");
                }

            }
            else
            {
                GameManager.instance.displayText(ingredient.name + ", wrong kitchenware");
            }

        }
    }
}
