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
            placeholders.Add(Instantiate(ingredient.Placeholder, location.transform.position, Quaternion.identity));
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
            //chance += Random.Range(ingredients[i].DeathChanceMin, ingredients[i].DeathChanceMax);
            if (Random.Range(0f, 100f) < ingredients[i].FailureRate)
            {
                multiplier += ingredients[i].Multiplier;
                GameManager.instance.displayText("Failed: " + ingredients[i].Name);
            }
        }

        float outcome = chance * multiplier;
        GameManager.instance.StartTimer(cookingDuration, outcome);
        StartCoroutine(clearPlaceholders());
    }

    public void enhanceProduct()
    {
        if(Random.Range(0f,100f) > ingredients[0].deathChance)
        {

        }
        ingredients[0].Multiplier = ingredients[0].Multiplier * 8;
        GameManager.instance.StartTimer(cookingDuration);
        print("enhance" + ingredients[0].Multiplier);
        StartCoroutine(clearPlaceholders());
    }

    private IEnumerator clearPlaceholders()
    {
        yield return new WaitForSeconds(cookingDuration);
        for (int i = 0; i < placeholders.Count; i++)
        {
            if(placeholders != null)
            {
                Destroy(placeholders[i].gameObject);
            }
        }
        for (int i = 0; i < ingredients.Count; i++)
        {
            if(ingredients[i] != null)
            {
                GameObject obj = ingredients[i].gameObject;
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.5f, obj.transform.position.z);
                obj.GetComponent<Ingredient>().type = Type.Stove;
                obj.SetActive(true);
            }
        }
        placeholders.Clear();
        ingredients.Clear();
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
