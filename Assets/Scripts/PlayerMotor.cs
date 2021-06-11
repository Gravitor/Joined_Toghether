using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] float squareSize;
    [SerializeField] Vector2 bounds;

    GameManager gm;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameManager.current;
    }

    void Start()
    {
        gm.input.World.Movement.performed += ctx => Move();
    }

    float saturate(float i)
    {
        if (i < 0.5f && i > 0)
        {
            return 0;
        }
        if (i > 0.5f && i > 0)
        {
            return 1;
        }
        if (i > -0.5f && i < 0)
        {
            return 0;
        }
        if (i < -0.5f && i < 0)
        {
            return -1;
        }

        return 0;
    }

    void Move()
    {
        var delta = gm.input.World.Movement.ReadValue<Vector2>();
        float x = saturate(delta.x);
        float z = saturate(delta.y);

        Vector3 destination = new Vector3(
            transform.position.x + x * squareSize, 
            transform.position.y, 
            transform.position.z + z * squareSize
            );

        if (destination.x < bounds.x / 2 * squareSize &&
            destination.x > -bounds.x / 2 * squareSize &&
            destination.z < bounds.y / 2 * squareSize &&
            destination.z > -bounds.y / 2 * squareSize)
        {
            rb.MovePosition(destination);
        }
    }
}
