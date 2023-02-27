using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPawn))]
public abstract class PlayerController : MonoBehaviour
{
    protected PlayerPawn pawn;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        pawn = GetComponent<PlayerPawn>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (pawn != null)
        {
            ProcessInputs();
        }
    }

    protected virtual void FixedUpdate()
    {
        if (pawn != null)
        {
            ProcessMovement();
        }
    }

    protected abstract void ProcessInputs();
    protected abstract void ProcessMovement();
}
