using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]private Transform m_camTransform;
    [SerializeField]private float m_mouseSensitivity;

    private Vector2 m_mouseMovement;
    private float xRotation;

    void Update()
    {
        m_mouseMovement.x = Input.GetAxis("Mouse X") * m_mouseSensitivity * Time.deltaTime;
        m_mouseMovement.y = Input.GetAxis("Mouse Y") * m_mouseSensitivity * Time.deltaTime;

        xRotation -= m_mouseMovement.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        m_camTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * m_mouseMovement.x);
    }
}
