using UnityEngine;
using UnityEngine.InputSystem;

public class CameraOrbita : MonoBehaviour
{
    [Header("Referências")]
    public Transform alvo;

    [Header("Configuração")]
    public float sensibilidade = 0.2f;
    public float distancia = 6f;
    public float alturaMin = -20f;
    public float alturaMax = 70f;

    private float _yaw;
    private float _pitch;

    void Start()
    {
        _yaw   = transform.eulerAngles.y;
        _pitch = transform.eulerAngles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible   = false;
        }
    }

    void LateUpdate()
    {
        if (alvo == null) return;

        Vector2 look = Mouse.current.delta.ReadValue();

        _yaw   += look.x * sensibilidade;
        _pitch -= look.y * sensibilidade;
        _pitch  = Mathf.Clamp(_pitch, alturaMin, alturaMax);

        Quaternion rotacao = Quaternion.Euler(_pitch, _yaw, 0f);
        Vector3 offset     = rotacao * new Vector3(0f, 0f, -distancia);

        transform.position = alvo.position + offset;
        transform.rotation = rotacao;
    }
}