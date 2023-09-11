using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusFollower : MonoBehaviour
{
    

    [SerializeField]
    private DocumentNavigator documentNavigator;

    [SerializeField]
    private Pupil pupil;

    private bool hasElement;

    private Vector3 currentScreenPos;

    private Vector3 currentWorldPos;

    [SerializeField]
    private Rigidbody2D body;



    [SerializeField, Min(0f)]
    private float moveSpeed = 1f;


    [SerializeField]
    private bool canLook = true;
    [SerializeField]
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hasElement = documentNavigator.currentElement != null;

        if (hasElement)
        {
            currentScreenPos = documentNavigator.currentElement.worldBound.center; 
            currentWorldPos = Camera.main.ScreenToWorldPoint(currentScreenPos);
            currentWorldPos = new Vector3(currentWorldPos.x, -currentWorldPos.y, 0f);

            
        }

        if (hasElement && body && canMove)
            MoveBody();

        if(pupil && hasElement && canLook)
        {
            pupil.Look(currentWorldPos);
        }
        else if (pupil)
        {
            pupil.CenterLook();
        }

    }

    private void MoveBody()
    {
        

        body.AddForce((currentWorldPos - body.transform.position) * moveSpeed * Time.fixedDeltaTime);

        body.velocity = Vector2.ClampMagnitude(body.velocity, moveSpeed);


        

        pupil.targetDialation = Mathf.Clamp(body.velocity.magnitude, 0.5f, 1f);


    }
}
