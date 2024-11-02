using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoPersonagem : MonoBehaviour
{
    public Transform _transform; // Transform do personagem
    public Transform cameraTransform; // Transform da câmera

    Vector3 Direcao = Vector3.zero;
    Vector2 rotacaoMouse;
    public int sensibilidade = 100; // Sensibilidade do mouse, pode ajustar na Unity

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Trava o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimento do personagem
        if (controller.isGrounded)
        {
            Direcao = new Vector3(Input.GetAxis("Horizontal") * 0.05F, Input.GetAxis("Jump") * 0.1F, Input.GetAxis("Vertical") * 0.05F);
            Direcao = transform.TransformDirection(Direcao);
        }

        Direcao.y -= 0.6F * Time.deltaTime;
        controller.Move(Direcao);

        // Controle da rotação da câmera
        Vector2 controleMouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        rotacaoMouse.x += controleMouse.x * sensibilidade * Time.deltaTime;
        rotacaoMouse.y -= controleMouse.y * sensibilidade * Time.deltaTime; // Invertido para comportamento comum

        // Limita a rotação vertical (eixo Y)
        rotacaoMouse.y = Mathf.Clamp(rotacaoMouse.y, -90f, 90f);

        // Aplica a rotação no eixo Y (rotação lateral) ao personagem
        _transform.eulerAngles = new Vector3(0f, rotacaoMouse.x, 0f);

        // Aplica a rotação no eixo X (para cima e para baixo) na câmera
        cameraTransform.localEulerAngles = new Vector3(rotacaoMouse.y, 0f, 0f);
    }
}
