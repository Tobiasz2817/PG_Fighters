using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float smoothTime = 0.01f;
    
    private Vector3 inputMovement;
    private Vector3 rayPoint;
    
    private PlayerInput playerInput;

    private Vector3 currentMovement;
    private Vector3 targetMovement;

    public override void OnNetworkSpawn() {
        if(!IsOwner) this.enabled = false;
    }

    private void Awake() {
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
        inputMovement.y = transform.position.y;
        targetMovement = inputMovement.normalized;

        currentMovement = Vector3.SmoothDamp(currentMovement,  targetMovement,ref currentMovement, smoothTime);
        transform.position += currentMovement * speed * Time.deltaTime;
        
        Debug.Log("I Move");
    }

    private void ReadMovement(InputAction.CallbackContext obj) {
        Debug.Log( " I Reading Movement: " + transform.name  + " IsOwner: " + IsOwner);
        inputMovement = obj.ReadValue<Vector3>();
    }
    private void ReadRayVector3(RaycastHit raycastHit) {
        rayPoint = raycastHit.point;
    }
}
