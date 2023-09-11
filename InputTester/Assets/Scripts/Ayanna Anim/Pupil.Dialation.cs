using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pupil.Dialation
public partial class Pupil : MonoBehaviour
{

    public enum DialationPreset
    {
        Default,
        Wide,
        Narrow
    }

    private const float defaultDialation = 1f;

    [Header("Dialation")]
    [SerializeField, Range(0.15f, 2f)]
    private float m_targetDialation;

    [SerializeField, Range(0.15f, 2f)]
    private float m_currentDialation;

    [SerializeField]
    private float m_dialationRate = 0.2f;

    


    public float targetDialation
    {
        get { return m_targetDialation; }
        set { m_targetDialation = Mathf.Clamp(value, 0.15f, 2f); }
    }

    public float currentDialation
    {
        get { return m_currentDialation; }
        set
        {
            m_targetDialation = value;
            m_currentDialation = value;
        }
    }



    

    public void DialateMax() { targetDialation = 2f; }

    public void DialateMin() { targetDialation = 0.15f; }

    public void UnDialate() { targetDialation = defaultDialation; }





    public void UpdateDialation()
    {
        if (m_currentDialation != m_targetDialation)
            m_currentDialation = Mathf.MoveTowards(currentDialation, targetDialation, m_dialationRate * Time.fixedDeltaTime);

        pupilTransform.localScale = Vector3.one * m_currentDialation;
    }

}
