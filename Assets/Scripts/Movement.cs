using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected ForceMode MyForceMode;
    [SerializeField] protected float ForcePower;
    [SerializeField] protected float SpeedRotation;
    [SerializeField] protected float ForceJump;
    protected float moveHorizontal;
    protected float moveVertical;

    [SerializeField] protected float maxMagnitude = 15;

    Rigidbody Plane;

    void Start()
    {
        Plane = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
       /* moveMouseVertical = Input.GetAxis("Mouse Y");
        moveMouseHorizontal = Input.GetAxis("Mouse X"); */
    }

    private void FixedUpdate()
    {
        MovementMove();
    }

    private void MovementMove()
    {
       /* if (Plane.velocity.magnitude > maxMagnitude)
        {
            Plane.velocity = Plane.velocity.normalized * maxMagnitude;
        } */
        Vector3 Force = new Vector3(-moveVertical * ForcePower, 0, moveHorizontal * ForcePower);
        Vector3 Rotate = new Vector3(moveHorizontal * SpeedRotation, 0, -moveVertical * SpeedRotation);
        Plane.AddRelativeForce(Force, MyForceMode);
        Plane.AddRelativeTorque(Rotate);
    }
}
