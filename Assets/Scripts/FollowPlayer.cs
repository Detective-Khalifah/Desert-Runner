using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public Quaternion playerRotationDirection;
    public Vector3 offset = new Vector3(0, 2, -1.75f);
    private Vector3 dest;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.zero);
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // Offset the camera behind the player
        dest = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, dest, Time.deltaTime);

        // Rotate Camera when player turns
        // playerRotationDirection = player.transform.rotation;
        playerRotationDirection = Quaternion.LookRotation(-offset, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(player.transform.rotation, playerRotationDirection, rotationSpeed);
    }
}
