using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLine : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] GameObject pointOne;
    [SerializeField] GameObject pointTwo;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        //StartCoroutine(Fade(text, 1.0f, true));
        StartCoroutine(Lerp(this.gameObject, 2.0f, 0.25f, true));
    }

    public GameObject firstPoint;
    public GameObject secondPoint;

    public IEnumerator Lerp(GameObject textObject, float duration, float distanceLeeway, bool right)
    {
        text.horizontalAlignment = right ? HorizontalAlignmentOptions.Left : HorizontalAlignmentOptions.Right;

        GameObject leftPoint = pointOne.transform.position.x < pointTwo.transform.position.x ? pointOne : pointTwo;
        GameObject rightPoint = leftPoint == pointOne ? pointTwo : pointOne;

        firstPoint = right ? leftPoint : rightPoint;
        secondPoint = firstPoint == leftPoint ? rightPoint : leftPoint;

        textObject.transform.position = firstPoint.transform.position;

        float timeElapsed = 0;
        while(timeElapsed < duration)
        {
            
            textObject.transform.SetPositionAndRotation(Vector3.Lerp(firstPoint.transform.position,
                                                                     secondPoint.transform.position,
                                                                     timeElapsed / duration),
                                                        Quaternion.identity);

            timeElapsed += Time.deltaTime;

            if(Vector3.Distance(textObject.transform.position, secondPoint.transform.position) < distanceLeeway)
            {
                yield break;
            }

            yield return null;
        }

    }

    public IEnumerator Fade(TMP_Text tmtext, float speed, bool fadeIn)
    {
        float R, G, B, A;

        R = tmtext.color.r;
        G = tmtext.color.g;
        B = tmtext.color.b;

        A = fadeIn ? 0 : 255;

        tmtext.color = new Color32((byte)R, (byte)G, (byte)B, (byte)A);

        for (int i = 0; i < (255 / speed); i++)
        {
            A = fadeIn ? A + speed : A - speed;

            Mathf.Clamp(A, 0, 255);

            tmtext.color = new Color32(255, 255, 255, (byte)A);

            yield return null;
        }
    }
}
