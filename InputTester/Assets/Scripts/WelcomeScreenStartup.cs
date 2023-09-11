using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WelcomeScreenStartup : MonoBehaviour
{
    private Color blank = new Color(0.8784314f, 0.8784314f, 0.8784314f, 0f );

    private Color offwhite = new Color(0.8784314f, 0.8784314f, 0.8784314f, 1f );


    [SerializeField]
    private UIDocument document;

    [SerializeField]
    private SpriteRenderer ayannaRenderer;

    private void OnEnable()
    {
        ayannaRenderer.color = blank;

        var bg = document.rootVisualElement.Q<GroupBox>("Background");
        bg.style.opacity = 0f;


        StartCoroutine(FadeInAyanna());
    }





    private IEnumerator FadeInAyanna()
    {
        yield return new WaitForSeconds(1f);


        var timeElapsed = 0f;
        while (timeElapsed < 1f)
        {
            ayannaRenderer.color = Color.Lerp(blank, offwhite, timeElapsed / 1f);

            yield return new WaitForFixedUpdate();
            timeElapsed += Time.fixedDeltaTime;

        }
        ayannaRenderer.color = offwhite;

        yield return new WaitForSeconds(1f);

        var bg = document.rootVisualElement.Q<GroupBox>("Background");
        bg.style.opacity = 1f;
    }


}
