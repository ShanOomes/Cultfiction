using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour, IInteractionBehavior
{
    private Animator anim;
    private Ingredient[] arrIngredients;
    private bool isOpen;

    public void interact()
    {
        if (isOpen)
        {
            anim.SetBool("isOpen", true);
        }
        else
        {
            anim.SetBool("isOpen", false);
            if(arrIngredients[0] != null && arrIngredients[1] != null && arrIngredients[2] != null)//only call if all 3 ingredients are added to stove
            {
                cookingTime(arrIngredients);
            }
            else
            {
                print("Not enough ingredients to cook");
            }
        }
        isOpen = !isOpen;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
        isOpen = true;
        arrIngredients = new Ingredient[3];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int index = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != null && index <= 3 && isOpen == false)//check is not null, if index doesnt exceed limit of 3, if stove is open
        {
            arrIngredients[index] = other.gameObject.GetComponent<IngredientDisplay>().ingredient;//cache colliding ingredient into array
            print(arrIngredients[index].name + " Added to the stove");
            other.gameObject.SetActive(false);
            index++;
        }
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
}
