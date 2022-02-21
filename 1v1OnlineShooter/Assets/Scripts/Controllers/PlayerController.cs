using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private float movementSpeed;
    private Rigidbody playerRigidbody;
    private Vector2 inputVector;
    private Vector3 moveVector;
    [SerializeField] private bool isPaused = false;

    [Header("Instances")]
    private GameManager gameManager;
    private SoundManager soundManager;
    private UIManager uiManager;

    void Start()
    {
        gameManager = GameManager.instance;
        soundManager = SoundManager.instance;
        playerRigidbody = GetComponent<Rigidbody>();
        uiManager = UIManager.instance;
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void OnMove(InputAction.CallbackContext context) // AD (Keyboard), Left Stick (Gamepad)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void OnPause(InputAction.CallbackContext context) // ESC (Keyboard), Button Start (Gamepad)
    {
        isPaused = context.performed;
    }

    void Movement()
    {
        moveVector.x = inputVector.x;
        moveVector.y = 0;
        moveVector.z = inputVector.y;
        playerRigidbody.MovePosition(playerRigidbody.position + moveVector * movementSpeed * Time.fixedDeltaTime);
    }
}
