using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Mover
{
    protected override void Start()
    {
        base.Start();
    }

    public void MoveForward(float speed)
    {
        //move position of rigidbody rank forward at speed
        rigidbodyComponent.MovePosition(rigidbodyComponent.transform.position += 
                                        (rigidbodyComponent.transform.up * (speed * Time.deltaTime)));
    }

    public void MoveRight(float speed)
    {
        //move position of rigidbody rank forward at speed
        rigidbodyComponent.MovePosition(rigidbodyComponent.transform.position += 
                                        (rigidbodyComponent.transform.right * (speed * Time.deltaTime)));
    }
}
