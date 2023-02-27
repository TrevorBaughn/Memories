using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : PlayerController
{
    #region KeyCodes
    [Header("Control Key Codes")]
    [SerializeField] private KeyCode moveUp;
    [SerializeField] private KeyCode moveDown;
    [SerializeField] private KeyCode moveLeft;
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode interact;
    #endregion KeyCodes

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void ProcessMovement()
    {
        if (Input.GetKey(moveUp))
        {
            pawn.MoveUp();
        }

        if (Input.GetKey(moveDown))
        {
            pawn.MoveDown();
        }

        if (Input.GetKey(moveLeft))
        {
            pawn.MoveLeft();
        }

        if (Input.GetKey(moveRight))
        {
            pawn.MoveRight();
        }

        
    }

    protected override void ProcessInputs()
    {
        if (Input.GetKeyDown(interact))
        {
            pawn.Interact();
        }
    }
}
