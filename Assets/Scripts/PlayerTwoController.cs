using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : PlayerController // INHERITANCE
{
    // Start is called before the first frame update
    public override void Start() // POLYMORPHISM
    {
        base.Start();
        if (DataManager.Instance.playerIndex == 2)
        {
            Physics.gravity = new Vector3(0, -18, 0);
            force = 50;
        }
    }
}