using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Fridge : Kitchenware
{
    public List<GameObject> listIngredients = new List<GameObject>();

    public Transform[] holders;

    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if(listIngredients.Count != 0)
        {
            for (int i = 0; i < amount; i++)
            {
                int randomIndex = Random.Range(0, listIngredients.Count);
                GameObject obj = listIngredients[randomIndex].gameObject;
                
                //Ingredient ing = obj.AddComponent<Ingredient>();
                //ing.Set("Test", 10f, 20f, 5f, 15, test, Type.Stove);

                Instantiate(obj, holders[i].transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
