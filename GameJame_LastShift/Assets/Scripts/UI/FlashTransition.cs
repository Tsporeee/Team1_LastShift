using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(UnityEngine.UI.Image))]
public class FlashTransition : MonoBehaviour
{

    UnityEngine.UI.Image _image = null;
    Coroutine _currentFlashRoutine = null;

    private void Awake()
    {
        _image = GetComponent<UnityEngine.UI.Image>();
    }
    
    public void StartFlash(float secondsForFlashIn, float secondsForFlashOut, float maxAlpha, Color newColor)
    {
        _image.color = newColor;

        // ensure maxAlpha isn't above 1
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        if(_currentFlashRoutine != null)
        {
            StopCoroutine(_currentFlashRoutine);
        }
        _currentFlashRoutine = StartCoroutine(Flash(secondsForFlashIn, secondsForFlashOut, maxAlpha));
    }

    IEnumerator Flash(float secondsForFlashIn, float secondsForFlashOut, float maxAlpha)
    {
        // animate flash in
        float flashInDuration = secondsForFlashIn;
        for (float t = 0; t <= flashInDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = _image.color; 
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
            _image.color = colorThisFrame;

            // wait until the next frame
            yield return null;
        }

        //animate flash out
        float flashOutDuration = secondsForFlashOut;
        for (float t = 0; t <= flashOutDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = _image.color; 
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOutDuration);
            _image.color = colorThisFrame;

            // wait until the next frame
            yield return null;
        }

        // ensure alpha is set to 0
        _image.color = new Color32(0, 0, 0, 0);
    }
}
