using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] protected Vector3 Offset;
    [SerializeField] protected float MouseSens = 1.0f;
    [SerializeField] protected float BackwardMove = 1.0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * MouseSens, transform.localEulerAngles.y + Input.GetAxis("Mouse X") * MouseSens, 0);
        Vector3 TargetPos = target.transform.TransformPoint(Offset);
        transform.position = TargetPos - transform.forward * BackwardMove;
    }
}
