using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaAbrir : MonoBehaviour
{
    public Animator _animator;

    private bool _colidindo;
    private bool _portaAberta = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _colidindo)
        {
            // Alterna entre abrir e fechar
            if (_portaAberta)
            {
                _animator.SetTrigger("Fechar");
            }
            else
            {
                _animator.SetTrigger("Abrir");
            }

            // Alterna o estado da porta
            _portaAberta = !_portaAberta;
        }
    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.CompareTag("Player"))
        {
            _colidindo = true;
        }
    }

    void OnTriggerExit(Collider _col)
    {
        if (_col.gameObject.CompareTag("Player"))
        {
            _colidindo = false;

            // Se a porta estiver aberta, fecha ao sair
            if (_portaAberta)
            {
                _animator.SetTrigger("Fechar");
                _portaAberta = false;
            }
        }
    }
}
