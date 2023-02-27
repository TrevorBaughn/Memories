using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    private HashSet<Collider2D> _interactableColliders = new HashSet<Collider2D>();


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<IInteractable>() != null)
        {
            _interactableColliders.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactableColliders.Remove(other);
    }

    private HashSet<Collider2D> GetInteractableColliders()
    {
        return _interactableColliders;
    }

    private IInteractable GetClosestInteractable()
    {

        HashSet<Collider2D> others = GetInteractableColliders();

        //find closest one
        Collider2D closestObject = null;
        float closest = 10;
        foreach(Collider2D other in others)
        {
            float dist = Vector2.Distance(other.transform.position, this.transform.position);
            if(dist < closest)
            {
                closest = dist;
                closestObject = other;
            }
        }


        //return it
        if (closestObject != null)
        {
            if(closestObject.gameObject.GetComponent<IInteractable>() != null)
            {
                return closestObject.gameObject.GetComponent<IInteractable>();
            }
        }
        return null;
        
    }

    public void Interact()
    {
        IInteractable toInteract = GetClosestInteractable();
     
        if (toInteract != null)
        {
            toInteract.OnInteract();
        }
    }

    
   


}
