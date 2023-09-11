using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//InputTracking

public partial class DocumentNavigator : MonoBehaviour
{

    

    //Variables
    private bool m_shiftHeld;



    //Properties
    public bool shiftHeld { get { return m_shiftHeld; } private set { m_shiftHeld = value; } }
}
