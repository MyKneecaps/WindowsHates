using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusFollower : Follower
{
    

    [SerializeField]
    private DocumentNavigator documentNavigator;

   

    private bool hasElement;

    

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        hasElement = documentNavigator.currentElement != null;

        if (hasElement)
        {
            currentScreenPos = documentNavigator.currentElement.worldBound.center; 
            ScreenToWorld(currentScreenPos);

            
        }

        if (hasElement && body && m_canMove)
            MoveBody();

        if(pupil && hasElement && m_canLook)
        {
            pupil.Look(currentWorldPos);
        }
        else if (pupil)
        {
            pupil.CenterLook();
        }

    }
}
