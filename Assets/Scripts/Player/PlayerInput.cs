using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private static MainControls controls;

    private bool canInput;

    private Vector2 newDirection;
    private PlayerController pController;

    private void Awake()
    {
        controls = new MainControls();
        pController = GetComponent<PlayerController>();
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
        newDirection = direction;
        UpdateMovement();
    }

    //Calls the primary action on the player
    private void OnPrimaryAction()
    {
        if (!canInput) { return; }

        pController.OnPrimaryAction();
    }

    //Calls the secondary action on the player
    private void OnSecondaryAction()
    {
        if (!canInput) { return; }

        pController.OnSecondaryAction();
    }

    //Updates the given movement with the player movement class
    private void UpdateMovement()
    {
        if (!canInput) { return; }

        pController.SetMovement(newDirection);

    }

    public void SetCanInput(bool _canInput)
    {
        canInput = _canInput;
    }
}
