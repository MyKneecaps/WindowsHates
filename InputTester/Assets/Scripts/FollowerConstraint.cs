using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FollowerConstraint : MonoBehaviour
{

    private BoxCollider2D m_box;

    public BoxCollider2D box { get { return m_box; } }

    private void Awake()
    {
        m_box = GetComponent<BoxCollider2D>();
    }


    public void Clamp(ref Vector2 point)
    {
        
        if (!box.bounds.Contains(point))
        {
            point = box.bounds.ClosestPoint(point);
        }
    }
}
