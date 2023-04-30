using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerPawn : Pawn, IKillable
{
    private PlayerMover _mover;
    private Interaction _interaction;
    [SerializeField] private PauseGame _pauseSystem;


    // Start is called before the first frame update
    private void Start()
    {
        //load references
        _mover = GetComponent<PlayerMover>();
        _interaction = GetComponentInChildren<Interaction>();
    }

    public void MoveUp()
    {
        //use the mover to move forward if not null
        if (_mover != null)
        {
            _mover.MoveForward(moveSpeed);
        }
    }
    public void MoveDown()
    {
        //use the mover to move backward if not null
        if (_mover != null)
        {
            _mover.MoveForward(-moveSpeed);
        }
    }
    public void MoveRight()
    {
        //use the mover to move backward if not null
        if (_mover != null)
        {
            _mover.MoveRight(moveSpeed);
        }
    }
    public void MoveLeft()
    {
        //use the mover to move backward if not null
        if (_mover != null)
        {
            _mover.MoveRight(-moveSpeed);
        }
    }

    public void Interact()
    {
        _interaction.Interact();
    }

    public void Pause()
    {
        //Note: Move Elsewhere
        _pauseSystem.TogglePause();  
    }

    /// <summary>
    /// Unloads the player pawn, to be loaded again later. 
    /// </summary>
    public void Die()
    {
        this.gameObject.SetActive(false);
    }
}
