using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimentodojogador : MonoBehaviour
{
    public float velocidadeDoJogador;

    public float alturaDoPulo;

    public Rigidbody2D oRigidbody2D;

    public SpriteRenderer oSpriteRenderer;

    public AudioSource somDoPulo;   

    public bool estaNoChao;
    
    public Transform verificadorDeChao;
    
    public float raioDeVerificacao;

    public LayerMask layerDoChao;
    
    private bool jaPulou = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarJogador();
        Pular();
        Debug.Log(estaNoChao);  
    }
    public void MovimentarJogador()

    {
        float inputDoMovimento = Input.GetAxisRaw("Horizontal");
        oRigidbody2D.velocity = new Vector2(inputDoMovimento * velocidadeDoJogador, oRigidbody2D.velocity.y);
        if (inputDoMovimento > 0)
        {
            oSpriteRenderer.flipX = false;

        }
        if (inputDoMovimento < 0)
        {
            oSpriteRenderer.flipX = true;
        }
    }

    public void Pular()
    {
        estaNoChao = Physics2D.OverlapCircle(verificadorDeChao.position, raioDeVerificacao, layerDoChao);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && estaNoChao == true)
        {
            oRigidbody2D.velocity = Vector2.up * alturaDoPulo;
            estaNoChao = false;

            somDoPulo.Play();

            jaPulou = true;
        }
        /*if (estaNoChao)
        {
            jaPulou = false;
        }*/
    }
}

     

