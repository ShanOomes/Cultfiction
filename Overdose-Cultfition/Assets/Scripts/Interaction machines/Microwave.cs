using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour, IInteractionBehavior
{
    private Animator anim;

    private bool isOpen;

    public void cookingTime(Ingredient[] ingredients)
    {
        throw new System.NotImplementedException();
    }

    public void interact()
    {
        if (isOpen)
        {
            anim.SetBool("isOpen", true);
        }
        else
        {
            anim.SetBool("isOpen", false);
        }
        isOpen = !isOpen;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
        isOpen = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
