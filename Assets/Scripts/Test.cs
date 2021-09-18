using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Ingredient[] array;

    private int index = 0;

    public Ingredient test;
    // Start is called before the first frame update
    void Start()
    {
        array = new Ingredient[10];
        array[index] = test;

        print(array[index].name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
