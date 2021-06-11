using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public DefaultInput input;
    public static GameManager current;

    private void Awake()
    {
        input = new DefaultInput();
        input.Enable();

        if (GameManager.current)
        {
            Destroy(GameManager.current);
        }
        else
        {
            current = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
