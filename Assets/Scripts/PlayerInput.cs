using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private static MainControls controls;

    private bool canInput;

    private Vector2 newDirection;

    private void Awake()
    {
        controls = new MainControls();
    }

    private void OnEnable()
    {
        controls.Enable();
        SetControlsEvent();
    }

    private void OnDisable()
    {
        RemoveControlsEvent();
        controls.Disable();
    }

    private void Start()
    {
        canInput = true;
    }

    private void Update()
    {
        if (canInput)
        {
            UpdateMovement();
        }
    }

    //Sets up all the events to the proper controls
    private void SetControlsEvent()
    {
        controls.Player.PrimaryAction.performed += PrimaryAction_performed;
        controls.Player.SecondaryAction.performed += SecondaryAction_performed;

        controls.Player.Move.performed += Direction_performed;
        controls.Player.Move.canceled += Direction_canceled;

    }

    private void RemoveControlsEvent()
    {
        controls.Player.PrimaryAction.performed -= PrimaryAction_performed;
        controls.Player.SecondaryAction.performed -= SecondaryAction_performed;

        controls.Player.Move.performed -= Direction_performed;
        controls.Player.Move.canceled -= Direction_canceled;
    }

    private void PrimaryAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPrimaryAction();
    }

    private void SecondaryAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSecondaryAction();
    }

    private void Direction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnDirection(obj.ReadValue<Vector2>());
    }

    private void Direction_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnDirection(Vector2.zero);
    }

    //Sets the direction for the player
    private void OnDirection(Vector2 direction)
    {
        Debug.Log("On Direction: " + direction.ToString());
        newDirection = direction;
        UpdateMovement();
    }

    //Calls the primary action on the player
    private void OnPrimaryAction()
    {
        //!TODO: Call primary action on player controller
        Debug.Log("OnPrimaryAction!");
    }

    //Calls the secondary action on the player
    private void OnSecondaryAction()
    {
        //!TODO: Call secondary action on player controller
        Debug.Log("OnSecondaryAction!");
    }

    //Updates the given movement with the base movement class
    private void UpdateMovement()
    {
        if (canInput)
        {
            //!TODO set direction in player controller here
        }
    }
}
