using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Substitui o Movimentacao.cs original.
/// Move o player relativo à câmera — WASD segue a visão, não o eixo do mundo.
///
/// Setup no Inspector:
///   cam         → arraste a Main Camera (não a CinemachineCamera)
///   velocidade  → velocidade de movimento
///   rotacionar  → true = o player vira para a direção do movimento
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Movimentacao : MonoBehaviour
{
    [Header("Referências")]
    public Camera cam;

    [Header("Configuração")]
    public float velocidade = 5f;
    public bool rotacionar = true;

    private CharacterController _controller;
    private Vector2 _moveInput;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        // Tenta encontrar a câmera automaticamente se não foi arrastada
        if (cam == null)
            cam = Camera.main;
    }

    // Chamado automaticamente pelo Input System (Send Messages)
    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        if (cam == null) return;

        // Pega as direções "para frente" e "para o lado" da câmera,
        // mas só no plano horizontal (sem inclinar o player)
        Vector3 frente = cam.transform.forward;
        Vector3 lado   = cam.transform.right;
        frente.y = 0f;
        lado.y   = 0f;
        frente.Normalize();
        lado.Normalize();

        // Combina com o input
        Vector3 direcao = frente * _moveInput.y + lado * _moveInput.x;

        // Move
        _controller.SimpleMove(direcao * velocidade);

        // Rotaciona o player para a direção que está andando
        if (rotacionar && direcao.sqrMagnitude > 0.01f)
        {
            Quaternion alvo = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Slerp(transform.rotation, alvo, Time.deltaTime * 10f);
        }
    }
}
