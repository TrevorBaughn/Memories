using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        this.gameObject.SetActive(false);
    }
}
