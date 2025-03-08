using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9f;
    public float sensitivityVer = 9f;

    public float minVert = -45f;
    public float maxVert = 45f;

    public float verticalRot = 0f;
    public float horizontalRot = 0f;
    public float delta = 0f;

    private void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null )
        {
            rigidbody.freezeRotation = true;
        }
    }


    void Update()
    {
        if(axes == RotationAxes.MouseX)
    {
            transform.Rotate(0, sensitivityHor * Input.GetAxis("Mouse X"), 0);
    }
        else if (axes == RotationAxes.MouseY)
        {
            verticalRot -= sensitivityVer * Input.GetAxis("Mouse Y");
            verticalRot = Mathf.Clamp(verticalRot, minVert, maxVert);
            horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        else
    {
            verticalRot -= sensitivityVer * Input.GetAxis("Mouse Y");
            verticalRot = Mathf.Clamp(verticalRot, minVert, maxVert);
            delta = Input.GetAxis("Mouse X") * sensitivityHor;


            horizontalRot = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }


}
