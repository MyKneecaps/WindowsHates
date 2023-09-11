using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;


public partial class DocumentNavigator : MonoBehaviour
{
    
    private EventSystem eventSystem;

    private GameObject m_currentSelection;

    private UIDocument selectedDocument;

    private PanelEventHandler m_panelEventHandler;


    private Focusable m_prevFocusable;
    public Focusable prevFocusable
    {
        get { return m_prevFocusable; }
    }

    private Focusable m_currentFocusable;
    public Focusable currentFocus
    {
        get { return m_currentFocusable; }
        set 
        { 
            if(m_currentFocusable != value) { m_prevFocusable = m_currentFocusable; }
            m_currentFocusable = value; 
        }
    }


    private VisualElement m_previousElement;
    public VisualElement previousElement
    {
        get { return m_previousElement; }
    }

    private VisualElement m_currentElement;
    public VisualElement currentElement
    {
        get { return m_currentElement; }
        set
        {
            if (m_currentElement != value) { m_previousElement = m_currentElement; }
            m_currentElement = value;
        }
    }


    private void Awake()
    {
        eventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        m_currentSelection = EventSystem.current.currentSelectedGameObject;

        if(!selectedDocument || selectedDocument.gameObject != m_currentSelection)
            UpdateSelectedUIDocument();
    }


    private void UpdateSelectedUIDocument()
    {
        if (!m_currentSelection)
        {
            selectedDocument = null;
        }

        else if (m_currentSelection.TryGetComponent<UIDocument>(out selectedDocument))
        {
            m_panelEventHandler = transform.GetEventHandlerInChildren();

            Debug.Log($"Selection Target: {m_panelEventHandler}");

            if (m_panelEventHandler)
            {
                eventSystem.SetSelectedGameObject(m_panelEventHandler.gameObject);

                currentFocus = m_panelEventHandler.GetFocusOfPanel(); 
            }
        }


        currentFocus = m_panelEventHandler ? m_panelEventHandler.GetFocusOfPanel() : null;


        if(currentFocus != null && currentFocus.IsElement(out var element))
        {
            currentElement = element;
        }
        else
        {
            currentElement = null;
        }
        
    }
}
