using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class WelcomeScreenStartup : MonoBehaviour
{
    private Color blank = new Color(0.8784314f, 0.8784314f, 0.8784314f, 0f );

    private Color offwhite = new Color(0.8784314f, 0.8784314f, 0.8784314f, 1f );


    [SerializeField]
    private UIDocument document;

    [SerializeField]
    private Follower follower;

    [SerializeField]
    private Pupil pupil;

    [SerializeField]
    private List<SpriteRenderer> ayannaRenderers;


    bool fadedIn;

    private float timeSinceLastMove;

    private Vector2 pointerPos;


    private void OnEnable()
    {
        ayannaRenderers.ForEach(item => item.color = blank);

        var bg = document.rootVisualElement.Q<GroupBox>("Background");
        bg.style.opacity = 0f;


        StartCoroutine(FadeInAyanna());
    }


    private void Update()
    {
        if (fadedIn)
            PointerCheck();
    }


    private void PointerCheck()
    {
        var newPos = Pointer.current.position.ReadValue();



        if (Mathf.Approximately(newPos.x, pointerPos.x) && Mathf.Approximately(newPos.y, pointerPos.y))
        {
            timeSinceLastMove += Time.fixedDeltaTime;
            if(timeSinceLastMove >= 60f) { follower.canLook = true; }
        }
        else if (timeSinceLastMove >= 60f)
        {
            StopCoroutine("StopPeeking");
            StartCoroutine("StopPeeking");
            pupil.currentDialation = 0.3f;
            follower.canLook = false;

            timeSinceLastMove = 0f;
        }
        else
        {
            timeSinceLastMove = 0f;
        }

        pointerPos = newPos;

        


        
    }


    private IEnumerator FadeInAyanna()
    {
        yield return new WaitForSeconds(1f);


        var timeElapsed = 0f;
        while (timeElapsed < 1f)
        {
            var color = Color.Lerp(blank, Color.white, timeElapsed / 1f);
            ayannaRenderers.ForEach(item => item.color = color);

            yield return new WaitForFixedUpdate();
            timeElapsed += Time.fixedDeltaTime;

        }

        ayannaRenderers.ForEach(item => item.color = Color.white);

        yield return new WaitForSeconds(1f);

        var bg = document.rootVisualElement.Q<GroupBox>("Background");
        bg.style.opacity = 1f;

        yield return new WaitForSeconds(3f);

        ayannaRenderers.ForEach(item => item.enabled = true);

        fadedIn = true;
        
    }

    private IEnumerator StopPeeking()
    {
        yield return new WaitForSeconds(0.5f);
        pupil.UnDialate();
        pupil.CenterLook();
        
    }


}
