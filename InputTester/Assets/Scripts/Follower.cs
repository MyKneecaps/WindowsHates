using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    


    [SerializeField]
    protected Pupil pupil;

    protected Vector2 currentScreenPos;

    protected Vector2 currentWorldPos;

    [SerializeField]
    protected Rigidbody2D body;



    [SerializeField, Min(0f)]
    protected float moveSpeed = 1f;


    [SerializeField]
    protected bool m_canLook = true;
    [SerializeField]
    protected bool m_canMove = true;

    public bool canLook { get { return m_canLook; } set { m_canLook = value; } }
    public bool canMove { get { return m_canMove; } set { m_canMove = value; } }

    [SerializeField]
    private bool invertX;
    [SerializeField]
    private bool invertY = true;

    protected float xAxis { get { return invertX ? -1f : 1f; } }
    protected float yAxis { get { return invertY ? -1f : 1f; } }


    [SerializeField]
    private FollowerConstraint constraint;


    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        

        if (body && m_canMove)
            MoveBody();

        if (pupil && m_canLook)
        {
            pupil.Look(currentWorldPos);
        }
        else if (pupil)
        {
            //pupil.CenterLook();
        }

    }

    protected virtual void MoveBody()
    {
        body.AddForce((currentWorldPos - (Vector2)body.transform.position) * moveSpeed * Time.fixedDeltaTime);

        body.velocity = Vector2.ClampMagnitude(body.velocity, moveSpeed);

        pupil.targetDialation = Mathf.Clamp(body.velocity.magnitude, 0.5f, 1f);


    }


    protected void ScreenToWorld(Vector2 pointerPos)
    {

        currentWorldPos = Camera.main.ScreenToWorldPoint(pointerPos);
        currentWorldPos = new Vector3(xAxis * currentWorldPos.x, yAxis * currentWorldPos.y, 0f);

        if (constraint)
        {
            constraint.Clamp(ref currentWorldPos);
        }
    }
}
