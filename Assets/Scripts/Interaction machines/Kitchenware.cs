using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchenware : MonoBehaviour, IInteractionBehavior
{
    private Ingredient[] arrIngredients;

    private bool isOpen;

    protected Animator anim;

    protected int maxIngredients = 0;

    public void initialize()
    {
        arrIngredients = new Ingredient[3];
        isOpen = false;
    }

    public bool SetIngredient(int index, Ingredient ingredient)
    {
        if(ingredient != null)
        {
            arrIngredients[index] = ingredient;
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

    public bool isArrayEmpty(int min)
    {
        int counter = 0;
        for (int i = 0; i < arrIngredients.Length; i++)
        {
            if (arrIngredients[i] == null)
            {
                counter++;
            }
        }

        if(counter < min)
        {
            return true;
        }
        return false;
    }
    public void cookingTime()
    {
        float chance = 0;
        float multiplier = 0;
        for (int i = 0; i < arrIngredients.Length; i++)
        {
            chance += Random.Range(arrIngredients[i].deathChanceMin, arrIngredients[i].deathChanceMax);

            multiplier += arrIngredients[i].multiplier;
        }

        float outcome = chance * multiplier;
        print("Cooked: " + outcome);
    }

    public void interact()
    {
        if (isOpen)
        {
            anim.SetBool("isOpen", false);
            if (isArrayEmpty(2))//are there atleast 2 ingredients in array
            {
                cookingTime();
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
