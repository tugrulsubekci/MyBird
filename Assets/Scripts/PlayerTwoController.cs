using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : PlayerController // INHERITANCE
{
    private float gravityMultiplier = 1.4f;
    // Start is called before the first frame update
    public override void Start() // POLYMORPHISM
    {
        base.Start();
        if (DataManager.Instance.playerIndex == 2)
        {
            Physics.gravity *= gravityMultiplier;
            force *= 10;
        }
    }
}