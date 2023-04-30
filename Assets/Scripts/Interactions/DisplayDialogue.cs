using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDialogue : MonoBehaviour, IInteractable
{
    [SerializeField] private Dialogue line;

    public void OnInteract()
    {

        StartCoroutine(line.PlayLines());
    }
}
