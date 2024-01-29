using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RotateNinetyAtInterval : MonoBehaviour
{
    [SerializeField]
    Image imageToRotate;

    [Range(0f, 2f), SerializeField]
    float moveTime = 1f;

    [Range(2f, 5f), SerializeField]
    float gapPeriod = 2f;

    private float netElapsedTime = 0f;

    private IEnumerator RotateObject()
    {
        float elapsedTime = 0f;
        float startingAngle = imageToRotate.transform.rotation.eulerAngles.y;
        float spinAngle = Math.Abs((startingAngle + 180) % 360);
        Vector3 endAngle = new Vector3(0f, spinAngle, 0f);

        while (elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;

            Vector3 lerpedAngle = Vector3.Lerp(
                imageToRotate.transform.rotation.eulerAngles,
                endAngle,
                elapsedTime / moveTime
            );

            imageToRotate.transform.rotation = Quaternion.Euler(lerpedAngle);
        }
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateObject());
    }

    void Update()
    {
        netElapsedTime += Time.deltaTime;
        if (netElapsedTime > gapPeriod + moveTime)
        {
            StopCoroutine(RotateObject());
            netElapsedTime = 0f;
            StartCoroutine(RotateObject());
        }
    }
}
