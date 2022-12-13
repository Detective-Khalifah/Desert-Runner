using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class JamesController : MonoBehaviour
{
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference jumpControl;

    private CharacterController controller;
    private Vector3 jamesVelocity;
    private Transform cameraMainTransform;
    private bool groundedJames;

    [SerializeField, Tooltip("James speed multiplier.")]
    private float jamesSpeed = 2.0f;
    [SerializeField, Tooltip("How high James should jump.")]
    private float jumpHeight = 1.0f;
    [SerializeField, Tooltip("Downwards force on the player.")]
    private float gravityForce = -9.81f;
    [SerializeField, Tooltip("Rotation speed multiplier.")]
    private float rotationSpeed = 4f;

    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraMainTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        groundedJames = controller.isGrounded;
        if (groundedJames && jamesVelocity.y < 0) jamesVelocity.y = 0f;

        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        // On X & Z axes
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * jamesSpeed);

        // if (move != Vector3.zero) gameObject.transform.forward = move;

        if (jumpControl.action.triggered && groundedJames) jamesVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityForce);

        // On Y axis
        jamesVelocity.y += gravityForce * Time.deltaTime;
        controller.Move(jamesVelocity * Time.deltaTime);

        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
