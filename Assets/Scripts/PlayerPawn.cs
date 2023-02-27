using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerPawn : Pawn, IKillable
{
    private PlayerMover mover;

    // Start is called before the first frame update
    private void Start()
    {
        //load mover
        mover = GetComponent<PlayerMover>();
    }

    public void MoveUp()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveForward(moveSpeed);
        }
    }
    public void MoveDown()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveForward(-moveSpeed);
        }
    }
    public void MoveRight()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveRight(moveSpeed);
        }
    }
    public void MoveLeft()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveRight(-moveSpeed);
        }
    }

    /// <summary>
    /// Unloads the player pawn, to be loaded again later. 
    /// </summary>
    public void Die()
    {
        this.gameObject.SetActive(false);
    }
}
