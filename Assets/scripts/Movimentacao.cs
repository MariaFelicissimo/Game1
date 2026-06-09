using UnityEngine;
using UnityEngine.InputSystem; // Certifique-se que isso está aqui

public class Movimentacao : MonoBehaviour
{
    public float velocidade = 5.0f;
    private CharacterController controller;
    private Vector2 moveInput;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Com o "Send Messages", o Unity chama isso automaticamente
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.SimpleMove(move * velocidade);
    }
}