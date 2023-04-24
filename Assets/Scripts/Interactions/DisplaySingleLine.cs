using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySingleLine : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueLine line;
    [SerializeField] private string _text;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnInteract()
    {

        StartCoroutine(line.PlayDialogue());
        line.gameObject.SetActive(true);
        TextMeshProUGUI text = line.GetComponent<TextMeshProUGUI>();
        text.text = _text;
    }
}
