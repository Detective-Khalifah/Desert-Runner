using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private GameObject player;
    private Rigidbody obstacleRb;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 chaseDirection = (player.transform.position - transform.position).normalized;
        obstacleRb.AddForce(chaseDirection * speed);

        // Destroy obstacles after player completes level
    }
}
