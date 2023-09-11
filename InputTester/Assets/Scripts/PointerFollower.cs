using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PointerFollower : Follower
{



    protected override void FixedUpdate()
    {

        currentScreenPos = Pointer.current.position.ReadValue();
        ScreenToWorld(currentScreenPos);

        base.FixedUpdate();
    }
}
