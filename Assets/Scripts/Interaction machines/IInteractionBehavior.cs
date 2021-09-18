using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractionBehavior 
{
    void interact();

    void cookingTime(Ingredient[] ingredients);
}
