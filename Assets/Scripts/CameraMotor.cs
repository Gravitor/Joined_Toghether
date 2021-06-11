using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMotor : MonoBehaviour
{
    public Vector3 offset;
    public float SensitivityX;
    public float SensitivityY;

    GameObject player;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseY = GameManager.current.input.World.MouseY.ReadValue<float>() * SensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 70f);

        transform.localRotation = Quaternion.Euler(xRotation, 0 , 0);

        float mouseX = GameManager.current.input.World.MouseX.ReadValue<float>() * SensitivityX * Time.deltaTime;

        yRotation += mouseX;

        player.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(0, yRotation, 0));       
    }
}
