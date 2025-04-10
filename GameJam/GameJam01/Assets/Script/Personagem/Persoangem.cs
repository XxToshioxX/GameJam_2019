using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persoangem : MonoBehaviour
{
    private Vector2 Direcao;
    public float Velocidade;
    public Transform Fundo;
    public int Estado = 0;

    Animator animator;
    void Start()
    {

        Velocidade = 7;
        Direcao = Vector2.zero;

        animator = this.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetInteger("Estado", Estado);
        InputPersonagem();
        transform.Translate(Direcao * Velocidade * Time.deltaTime);
        Fundo.Translate(Direcao * Velocidade/2 * Time.deltaTime);
    }
    public void InputPersonagem()
    {
        Direcao = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -2)
        {
            Direcao += Vector2.left;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("Andando", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Direcao += Vector2.right;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Andando", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) )
        {
            animator.SetBool("Andando", false);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Andando", false);

        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y<6)
        {
            Direcao += Vector2.up;
            animator.SetBool("Andando", true);

        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y>-3)
        {
            Direcao += Vector2.down;
            animator.SetBool("Andando", true);

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("Andando", false);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("Andando", false);

        }
        
    }
    public void retornaEstado(int estado)
    {
        Estado = estado;
    }
    void Mudar()
    {
        if(Estado == 0) //Roxo
        {
            animator.SetInteger("Estado",0);
        }
        else if (Estado == 1) // Azul
        {
            animator.SetInteger("Estado", 1);
        }
        else if (Estado == 2) //Vermelho
        {
            animator.SetInteger("Estado", 2);
        }
        else if (Estado == 3) //Amarelo
        {
            animator.SetInteger("Estado", 3);
        }
    }
}
