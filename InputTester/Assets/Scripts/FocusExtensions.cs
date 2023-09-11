using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
public static class FocusExtensions
{
    public static Focusable GetFocusOfPanel(this PanelEventHandler eventHandler)
    {

        if (!eventHandler || eventHandler.panel == null || eventHandler.panel.focusController == null)
        {
            return null;
        }

        else
        {
            return eventHandler.panel.focusController.focusedElement;
        }
    }

    public static bool IsOfType<T>(this Focusable self, out T output) where T : VisualElement
    {
        if (self is T)
        {
            output = self as T;
            return true;
        }
        else
        {
            output = null;
            return false;
        }
    }

    public static bool IsElement(this Focusable self, out VisualElement output)
    {

        if (self.IsOfType<VisualElement>(out var element) && element.parent is DropdownField dropdown)
        {
            var children = element.Children().ToArray();
            output = children[dropdown.index];

            Debug.Log($"Index of {dropdown.index}: {output}");

            return true;
        }

        if (self.IsOfType<VisualElement>(out output))
        {
            return true;
        }

        else 
        { 
            return false; 
        }
        

    }


    public static VisualElement GetChildAt(this VisualElement self, int index)
    {
        var children = self.contentContainer.Children().ToArray();

        if(index >= children.Length) { Debug.LogError($"{index} is less than {children.Length}"); }

        return children[index];
    }



    public static bool TryGetAncestor<T>(this VisualElement self, out T output) where T : VisualElement
    {
        output = self.GetFirstAncestorOfType<T>();
        return output != null;
    }


    public static PanelEventHandler GetEventHandlerInChildren(this Transform self)
    {
        for(int i = 0; i < self.childCount; i++)
        {
            if(self.GetChild(i).gameObject.TryGetComponent<PanelEventHandler>(out var panelEventHandler))
            {
                return panelEventHandler;
            }
        }

        return null;
    }


    public static Vector2 SizeToWorld(this VisualElement self)
    {
        var baseBound = self.worldBound;

        var topLeft = Camera.main.ScreenToWorldPoint(baseBound.min);
        var bottomRight = Camera.main.ScreenToWorldPoint(baseBound.max);

        var width = bottomRight.x - topLeft.x;
        var height = bottomRight.y - topLeft.y;

        return new Vector2(width, height);
    }
}
