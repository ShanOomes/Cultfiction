using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchenware : MonoBehaviour, IInteractionBehavior
{
    private Ingredient[] arrIngredients;

    private bool isOpen;

    protected Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        arrIngredients = new Ingredient[3];
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetIngredient(int index, Ingredient ingredient)
    {
        if(ingredient != null)
        {
            arrIngredients[0] = ingredient;
            return true;
        }
        return false;
    }

    public Ingredient GetIngredient(int index)
    {
        return arrIngredients[index];
    }

    public Ingredient[] GetIngredients()
    {
        return arrIngredients;
    }

    public bool StoveOpened()
    {
        return isOpen;
    }
    public bool IsArrNull()
    {
        int nullCount = 0;
        for (int i = 0; i < arrIngredients.Length; i++)
        {
            if(arrIngredients[i] == null)
            {
                nullCount++;
            }
        }

        if(nullCount > 0)
        {
            return false;
        }
        return true;
    }

    public void cookingTime(Ingredient[] ingredients)
    {
        float chance = 0;
        float multiplier = 0;
        for (int i = 0; i < ingredients.Length; i++)
        {
            chance += Random.Range(ingredients[i].deathChanceMin, ingredients[i].deathChanceMax);

            multiplier += ingredients[i].multiplier;
        }

        float outcome = chance * multiplier;
        print("Cooked: " + outcome);
    }

    public void interact()
    {
        if (isOpen)
        {
            anim.SetBool("isOpen", false);
            print("Trying to cook");
            if (arrIngredients[0] != null)//only call if all 3 ingredients are added to stove
            {
                print("Cooking");
                cookingTime(arrIngredients);
            }
            else
            {
                print("Not enough ingredients to cook");
            }
        }
        else
        {
            anim.SetBool("isOpen", true);

        }
        isOpen = !isOpen;
    }
}
