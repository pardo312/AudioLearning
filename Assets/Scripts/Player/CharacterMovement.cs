using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float speed;
    [SerializeField]private AudioSource[] clips;
    private Vector2 direction;
    private Rigidbody rigibody;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigibody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        direction.x = Input.GetAxis("Horizontal") * speed;
        direction.y = Input.GetAxis("Vertical") * speed;
    }

    public void FixedUpdate()
    {
        if (direction.x != 0 || direction.y != 0)
        {
            rigibody.MovePosition(transform.position + transform.right * direction.x + transform.forward * direction.y);
            for (int i = 0; i < clips.Length; i++)
            {
                clips[i].reverbZoneMix = 1;
                if(!clips[i].isPlaying)
                    clips[i].Play();
            }
        }
        else
        {

            for (int i = 0; i < clips.Length; i++)
            {
                clips[i].Stop();
            }
        }
    }
}
