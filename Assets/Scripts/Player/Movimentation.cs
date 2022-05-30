using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentation : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 3f;
    public float gravity = -19.62f;
    public float jumpHeigth = 2.5f;
    public float lookSensivity = 200f;
    public LayerMask layerMask;
    Vector3 velocity;
    bool isRunningAnimation = false;
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float rotation = horizontal * lookSensivity * Time.deltaTime;
        Vector3 playerOrigin = transform.position + controller.center;
        isRunningAnimation = gameObject.GetComponent<CharacterAnimator>().isRunningA;
        if (isRunningAnimation)
        {
            speed = 9f;
        }
        else
        {
            speed = 3f;
        }

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeigth * -2f * gravity);
        }

        controller.Move(transform.forward * vertical * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        controller.transform.Rotate(new Vector3(0f, rotation, 0f));
        controller.Move(velocity * Time.deltaTime);
    }
}
