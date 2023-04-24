using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLine : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        StartCoroutine(Fade(text, 1.0f, true));
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
