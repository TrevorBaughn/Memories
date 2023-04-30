using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] List<string> lines;
    [SerializeField] float lerpTime = 3.0f;
    [SerializeField] bool lerpRight = true;
    [SerializeField] float fadeTime = 1.5f;
    [SerializeField] float timeBetweenLines = 1.0f;
    [SerializeField] GameObject pointOne;
    [SerializeField] GameObject pointTwo;
    private TextMeshProUGUI text;
    private GameObject textObject;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        textObject = text.gameObject;
        textObject.SetActive(false);
    }

    public IEnumerator PlayLines()
    {
        if (!textObject.activeInHierarchy)
        {
            for(int i = 0; i < lines.Count; i++)
            {
                yield return StartCoroutine(Play(i, lerpTime, lerpRight, fadeTime));
                yield return new WaitForSeconds(timeBetweenLines);
                
            }
        }


    }


    public IEnumerator Play(int lineIndex = 0,
                            float lerpTime = 3.0f, 
                            bool lerpRight = true, 
                            float fadeTime = 1.5f
                            )
    {
        if (!textObject.activeInHierarchy)
        {
            textObject.SetActive(true);

            text.text = lines[lineIndex];

            StartCoroutine(Fade(fadeTime, true));
            StartCoroutine(Lerp(text.gameObject, lerpTime, 0.05f, lerpRight));
            yield return new WaitForSeconds(lerpTime - fadeTime);

            yield return StartCoroutine(Fade(fadeTime, false));

            text.gameObject.SetActive(false);
        }
            
    }


    private IEnumerator Lerp(GameObject textObject, float duration, float distanceLeeway, bool right)
    {
        //text.horizontalAlignment = right ? HorizontalAlignmentOptions.Left : HorizontalAlignmentOptions.Right;
        textObject.GetComponent<TextMeshProUGUI>().horizontalAlignment = HorizontalAlignmentOptions.Center;

        GameObject leftPoint = pointOne.transform.position.x < pointTwo.transform.position.x ? pointOne : pointTwo;
        GameObject rightPoint = leftPoint == pointOne ? pointTwo : pointOne;

        GameObject firstPoint = right ? leftPoint : rightPoint;
        GameObject secondPoint = firstPoint == leftPoint ? rightPoint : leftPoint;

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
                textObject.transform.position = secondPoint.transform.position;
                yield break;
            }

            yield return null;
        }

    }

    private IEnumerator Fade(float duration, bool fadeIn)
    {
        float R, G, B, A;
        
        R = text.color.r;
        G = text.color.g;
        B = text.color.b;

        A = fadeIn ? 0 : 255;

        text.color = new Color32((byte)R, (byte)G, (byte)B, (byte)A);

        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            A = fadeIn ? Mathf.Lerp(0, 255, timeElapsed / duration) : Mathf.Lerp(255, 0, timeElapsed / duration);

            //Mathf.Lerp(A, 255, timeElapsed / duration);

            text.color = new Color32(255, 255, 255, (byte)A);

            timeElapsed += Time.deltaTime;

            if (fadeIn)
            {
                if(A > 250)
                {
                    A = 255;
                    yield break;
                }
            }
            else
            {
                if (A < 5)
                {
                    A = 0;
                    yield break;
                }
            }

            yield return null;
        }
    }
}
