using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class SceneChangeButton : MonoBehaviour
{

    [SerializeField]
    private UIDocument m_uiDocument;

    [SerializeField]
    private string m_buttonName;

    [SerializeField]
    private string m_sceneName;

    [SerializeField]
    private bool m_canLoad;


    private Button m_button;


    public UIDocument uiDocument { get { return m_uiDocument; } }

    public string buttonName { get { return m_buttonName; } }
    public string sceneName { get { return m_sceneName; } }

    public bool canLoad { get { return m_canLoad; } set { canLoad = value; } }



    private void Start()
    {
        uiDocument.rootVisualElement.Q<Button>(buttonName);
    }




}
