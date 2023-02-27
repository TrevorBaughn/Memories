using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPrintToConsole : MonoBehaviour, IInteractable
{
    [SerializeField] private string _text;

    public void OnInteract()
    {
        Debug.Log(_text);
    }
}
