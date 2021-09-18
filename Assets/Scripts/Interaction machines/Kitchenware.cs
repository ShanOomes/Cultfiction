using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchenware : MonoBehaviour, IInteractionBehavior
{
    private Ingredient[] arrIngredients;

    private GameObject[] arrHolders;

    private bool isOpen;

    protected Animator anim;

    private int maxIngredients;

    public void initialize(int max)
    {
        arrIngredients = new Ingredient[10];
        arrHolders = new GameObject[3];

        isOpen = false;
        maxIngredients = max;
    }

    public void SetPlaceholder(int index, GameObject obj)
    {
        arrHolders[index] = Instantiate(arrIngredients[index].placeholder, obj.transform.position, Quaternion.identity);
    }

    public bool SetIngredient(int index, Ingredient ingredient)
    {
        if(ingredient != null && arrayCount() < maxIngredients)
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

    public int arrayCount()
    {
        int counter = 0;
        for (int i = 0; i < arrIngredients.Length; i++)
        {
            if (arrIngredients[i] != null)
            {
                counter++;
            }
        }
        return counter;
    }
    public void cookingTime()
    {
        float chance = 0;
        float multiplier = 0;
        for (int i = 0; i < arrayCount(); i++)
        {
            chance += Random.Range(arrIngredients[i].deathChanceMin, arrIngredients[i].deathChanceMax);

            multiplier += arrIngredients[i].multiplier;
        }

        float outcome = chance * multiplier;
        print("Cooked: " + outcome);
        StartCoroutine(clearPlaceholders());
    }

    public IEnumerator clearPlaceholders()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < arrHolders.Length; i++)
        {
            Destroy(arrHolders[i].gameObject);
        }
    }

    public void interact()
    {
        if (isOpen)
        {
            anim.SetBool("isOpen", false);
            if (arrayCount() >= 2)//are there atleast 2 ingredients in array
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
