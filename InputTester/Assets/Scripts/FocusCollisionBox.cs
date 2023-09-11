using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCollisionBox : MonoBehaviour
{
    [SerializeField]
    private DocumentNavigator documentNavigator;

    private bool hasElement;

    private Vector3 currentScreenPos;

    private Vector3 currentWorldPos;

    [SerializeField]
    private Transform body;


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hasElement = documentNavigator.currentElement != null;

        body.gameObject.SetActive(hasElement);

        if (hasElement)
        {
            

            currentScreenPos = documentNavigator.currentElement.worldBound.center;
            currentWorldPos = Camera.main.ScreenToWorldPoint(currentScreenPos);
            currentWorldPos = new Vector3(currentWorldPos.x, -currentWorldPos.y, 0f);

            body.position = currentWorldPos;


            body.localScale = documentNavigator.currentElement.SizeToWorld();
        }

        

    }

   
}
