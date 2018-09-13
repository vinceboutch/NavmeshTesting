using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityConstantForceScript : MonoBehaviour
{
    [Tooltip("Gravity force to apply to the GameObject.")]
    [SerializeField]
    private float gravityForce = 1;

    private bool isDebuging;
    private CharacterController characterController;
    private Vector3 direction;

    private void Awake()
    {
        this.characterController = GetComponent<CharacterController>();
        direction = new Vector3(0, -gravityForce, 0);
    }

    private void FixedUpdate()
    {
        characterController.SimpleMove(direction);
    }

    private void SayToLog(string message)
    {
        if (isDebuging)
        {
            Debug.Log(message);
        }
    }
}
