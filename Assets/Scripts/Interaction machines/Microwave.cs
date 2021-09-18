using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : Kitchenware
{
    private int volume;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        volume = 3;

        initialize(volume);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
