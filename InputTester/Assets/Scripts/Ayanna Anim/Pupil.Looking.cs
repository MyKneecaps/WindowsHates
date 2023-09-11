using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pupil.Looking
public partial class Pupil : MonoBehaviour
{

    [Header("Pupil Movement")]
    [SerializeField]
    private float m_pupilMoveRate = 0.1f;
    [SerializeField]
    private float m_maxDistanceFromCenter = 0.2f;
    private Vector3 m_lookTarget;
    protected Vector3 center { get { return pupilTransform.parent.position; } }



    private void UpdatePupilDirection()
    {
        var lookRay = new Ray2D(center, m_lookTarget - center);
        var distance = Vector2.Distance(m_lookTarget, center);
        var clampedDistance = Mathf.Clamp(distance, 0f, m_maxDistanceFromCenter);

        Vector2 targetPoint = lookRay.GetPoint(clampedDistance);

        pupilTransform.position = Vector2.MoveTowards(pupilTransform.position, targetPoint, m_pupilMoveRate);
    }


    public void CenterLook()
    {
        m_lookTarget = center;
    }

    public void Look(Vector3 target)
    {
        m_lookTarget = target;
    }
}
