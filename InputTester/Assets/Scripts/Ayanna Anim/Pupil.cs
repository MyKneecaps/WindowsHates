using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Pupil : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private SpriteRenderer m_renderer;

    public SpriteRenderer spriteRenderer { get { return m_renderer; } }
    public Transform pupilTransform { get { return m_renderer.transform; } }



    


    private void Start()
    {
        CenterLook();
        UnDialate();
    }


    private void FixedUpdate()
    {
        UpdatePupilDirection();
        UpdateDialation();
    }


    

}
