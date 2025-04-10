using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 Direcao;
    public float Velocidade;
    public Transform Fundo;

    Animator animator;
    void Start()
    {
        Velocidade = 7;
        Direcao = Vector2.zero;

        animator = this.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        InputPersonagem();
    }
    public void InputPersonagem()
    {
        Direcao = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
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
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Andando", false);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Andando", false);

        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 6)
        {
            Direcao += Vector2.up;
            animator.SetBool("Andando", true);

        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -3)
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
}