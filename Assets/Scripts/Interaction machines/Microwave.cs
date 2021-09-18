using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : Kitchenware
{

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
