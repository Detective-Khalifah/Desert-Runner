using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 1.0f;
    public float turnSpeed = 25.0f;
    private float turnInput, movementInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // User Input
        turnInput = Input.GetAxis("Horizontal");
        movementInput = Input.GetAxis("Vertical");

        // Move player forwards/backwards
        transform.Translate(Vector3.forward * Time.deltaTime * speed * movementInput);

        // Turn player sideways
        transform.Rotate(Vector3.up, turnSpeed * turnInput * Time.deltaTime);
    }
}
