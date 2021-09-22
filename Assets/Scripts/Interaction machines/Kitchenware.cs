using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Kitchenware : MonoBehaviour, IInteractionBehavior
{
    private List<Ingredient> ingredients = new List<Ingredient>();

    private List<GameObject> placeholders = new List<GameObject>(); 

    private bool isOpen = false;

    protected Animator anim;

    protected int maxIngredients;

    public float cookingDuration;

    public bool SetIngredient(Ingredient ingredient, Transform location)
    {
        if(ingredient != null && ingredients.Count < maxIngredients)
        {
            ingredients.Add(ingredient);
            placeholders.Add(Instantiate(ingredient.placeholder, location.transform.position, Quaternion.identity));
            return true;
        }
        return false;
    }

    public int AmountOfIngredients()
    {
        return ingredients.Count;
    }

    public bool IsMaxFilled()
    {
        if(ingredients.Count < maxIngredients)
        {
            return true;
        }
        return false;
    }
    public bool ContainsIngredient(Ingredient ingredient)
    {
        return ingredients.Contains(ingredient);
    }

    public bool kitchenWareOpened()
    {
        return isOpen;
    }

    public void cookingTime()
    {
        float chance = 0;
        float multiplier = 0;
        for (int i = 0; i < ingredients.Count; i++)
        {
            chance += Random.Range(ingredients[i].deathChanceMin, ingredients[i].deathChanceMax);
            if (Random.Range(0f, 100f) > ingredients[i].failureRate)
            {
                multiplier += ingredients[i].multiplier;
                GameManager.instance.displayText("Failed: " + ingredients[i].name);
            }
        }

        float outcome = chance * multiplier;
        GameManager.instance.StartTimer(cookingDuration, outcome);
        //clearPlaceholders();
    }

    public void enhanceProduct()
    {
        float tmp;

        tmp = ingredients[0].deathChanceMax;
        tmp = tmp * 25;
        GameManager.instance.StartTimer(cookingDuration);
        print("enhance" + tmp);
    }

    private void clearPlaceholders()
    {
        for (int i = 0; i < placeholders.Count; i++)
        {
            if(placeholders != null)
            {
                Destroy(placeholders[i].gameObject);
            }
        }
    }

    public virtual void Action() { 
    
    }

    public void interact()
    {
        if(GameManager.instance.isCooking == false)
        {
            if (isOpen)
            {
                anim.SetBool("isOpen", false);

                Action();
            }
            else
            {
                anim.SetBool("isOpen", true);
            }
        }
        isOpen = !isOpen;
    }
}
