using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Vector3 inputMovement;
    private Vector3 rayPoint;

    private CharacterController characterController;
    private PlayerInput playerInput;

    private float distance;
    
    
    private void Awake() {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable() {
        playerInput.currentActionMap["Movement"].performed += ReadMovement;
        CameraRay.OnDetected += ReadRayVector3;
    }


    private void OnDisable() {
        playerInput.currentActionMap["Movement"].performed -= ReadMovement;
        CameraRay.OnDetected -= ReadRayVector3;
    }

    private void Update() {
        
        RotateCharacter();
        MoveCharacter();
    }

    private void RotateCharacter() {
        transform.LookAt(rayPoint);
    }

    private void MoveCharacter() {
        characterController.Move(inputMovement * speed * Time.deltaTime);
    }

    private void ReadMovement(InputAction.CallbackContext obj) {
        inputMovement = obj.ReadValue<Vector3>();
    }
    private void ReadRayVector3(RaycastHit raycastHit) {
        rayPoint = raycastHit.point;
    }
}
