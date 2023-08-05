using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StageSlider : MonoBehaviour
{
    [SerializeField] float length;
    [SerializeField] float duration = 0.3f;

    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;

    [SerializeField] Transform slider;

    private bool tweening = false;

    public void SlideRight()
    {
        if (tweening)
            return;

        if (slider.localPosition.x <= length)
            return;

        AudioManager.Instance.PlaySystem("ButtonClick");
        StartCoroutine(SlideCoroutine(-1920f));
    }

    public void SlideLeft()
    {
        if (tweening)
            return;

        if (slider.localPosition.x >= 0)
            return;

        AudioManager.Instance.PlaySystem("ButtonClick");
        StartCoroutine(SlideCoroutine(1920f));
    }

    private IEnumerator SlideCoroutine(float factor)
    {
        tweening = true;

        float timer = 0f;
        Vector3 startPos = slider.localPosition;
        Vector3 endPos = startPos;
        endPos.x += factor;

        while (timer < duration)
        {
            slider.localPosition = Vector3.Lerp(startPos, endPos, timer / duration);

            timer += Time.deltaTime;
            yield return null;
        }

        slider.localPosition = endPos;
        tweening = false;
    }
}
