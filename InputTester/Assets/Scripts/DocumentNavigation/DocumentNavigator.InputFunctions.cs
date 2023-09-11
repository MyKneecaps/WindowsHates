using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

//InputFunctions
public partial class DocumentNavigator : MonoBehaviour
{
    public void OnTab()
    {
        Debug.Log("Tab!");
    }

    public void OnShift()
    {
        Debug.Log("Shift!");
        shiftHeld = true;
    }

    public void OnUnShift()
    {
        Debug.Log("Unshift!");
        shiftHeld = false;
    }

    public void OnSubmit()
    {
        Debug.Log($"Got Submit event. Current focused: {currentFocus}");

        if(currentFocus != null && currentFocus.IsOfType<VisualElement>(out var element))
        {
            Debug.Log(element.worldTransform.GetPosition());
        }
    }

    public void OnNavigate()
    {
        if (currentFocus != null && currentElement.TryGetAncestor<ScrollView>(out var scrollView) && previousElement is DropdownField dropdown)
        {

            //dropdown.r
            //Debug.Log($"ChildCount of {currentElement}: {currentElement.childCount} vs Dropdown Index: {dropdown.index}");

            //var child = currentElement.GetChildAt(dropdown.index);

            //Debug.Log($"Got Nav event. Output: {child}, Index: {dropdown.index}");
        }

        else if(currentFocus != null)
        {
            Debug.Log("Got Nav event.");
        }
    }

}
