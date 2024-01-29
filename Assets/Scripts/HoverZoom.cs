using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverZoom
    : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        ISelectHandler,
        IDeselectHandler
{
    private Vector3 _startScale;
    private Vector3 _startPosition;

    [Range(0f, 2f), SerializeField]
    float scaleAmount = 1.25f;

    [Range(0f, 1f), SerializeField]
    float moveTime = 0.1f;

    [Range(-2f, 2f), SerializeField]
    float moveX = 0f;

    [Range(-2f, 2f), SerializeField]
    float moveY = 0f;

    void Start()
    {
        _startPosition = transform.position;
        _startScale = transform.localScale;
    }

    private IEnumerator MoveCard(bool startingAnimation)
    {
        Vector3 endPosition;
        Vector3 endScale;

        float elapsedTime = 0f;
        while (elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;

            if (startingAnimation)
            {
                endPosition = _startPosition + new Vector3(0f + moveX, 0.2f + moveY, -2.0f);
                endScale = _startScale * scaleAmount;
            }
            else
            {
                endPosition = _startPosition;
                endScale = _startScale;
            }

            Vector3 lerpedPosition = Vector3.Lerp(
                transform.position,
                endPosition,
                elapsedTime / moveTime
            );
            Vector3 lerpedScale = Vector3.Lerp(
                transform.localScale,
                endScale,
                elapsedTime / moveTime
            );

            transform.position = lerpedPosition;
            transform.localScale = lerpedScale;

            yield return null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        StartCoroutine(MoveCard(true));
    }

    public void OnDeselect(BaseEventData eventData)
    {
        StartCoroutine(MoveCard(false));
    }
}
