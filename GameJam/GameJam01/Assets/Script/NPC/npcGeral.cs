using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcGeral : MonoBehaviour
{
    //Determina o estado do npc
    public int estado;
    public int sprite;

    public float speed = 1.0F;
    public GameObject fim;

    Vector3 a, b, c;
    
    
    private float startTime; // tempo real
    private float journeyLength;
    private bool ativo = true;
    private bool mexer = true;
    private bool normal = true;
    private bool Ai = true; //ativo interaçao
    float fractionOfJourney;
    float distCovered;
    public Animator animator;
    public Transform target;

    //Posição que ele está olhando
    private float posAnt, posAtu;

    private int collisionCount = 0;


    void Start()
    {
        a = gameObject.transform.position;
        b = fim.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(a, b);

        animator = GetComponent<Animator>();

        animator.SetInteger("Estado", sprite);
    }

    void Update()
    {
        animator.SetInteger("Estado", sprite);
        if (collisionCount < 1)
        {
            mexendo();
            atualizaOLado();

        }
        else
        {
            normal = false;
            c = gameObject.transform.position;
            startTime = Time.time;
        }
    }

    void atualizaOLado()
    {
        posAtu = gameObject.transform.position.x;
        if (posAnt > posAtu)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        posAnt = posAtu;

    }

    void mexendo()
    {
        if (estado == 1)
        {
            if (mexer == true)
            {
                distCovered = (Time.time - startTime) * speed;
                fractionOfJourney = distCovered / journeyLength;
                if (normal)
                {
                    if (ativo)
                    {
                        transform.position = Vector3.Lerp(a, b, fractionOfJourney);
                        animator.SetBool("Andando", true);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(b, a, fractionOfJourney);
                        animator.SetBool("Andando", true);
                    }   
                }
                else
                {
                    if (Ai)
                    {
                        transform.position = Vector3.Lerp(c, b, fractionOfJourney);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(c, a, fractionOfJourney);
                    }

                }
                if (transform.position == b)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    startTime = Time.time;
                    ativo = false;
                    normal = true;
                    Ai = false;

                }

                if (transform.position == a)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    startTime = Time.time;
                    ativo = true;
                    normal = true;
                    Ai = true;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        collisionCount++;
        animator.SetBool("Andando", false);
        startTime = Time.time;

    }

    void OnTriggerExit2D(Collider2D col)
    {
        animator.SetBool("Andando", false);
        collisionCount--;
      
        startTime = Time.time;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (estado == 2)
            {
                mexer = false;
                distCovered = (Time.time - startTime) * 3;
                fractionOfJourney = distCovered / journeyLength;
                if (other.transform.position.x < this.transform.position.x)
                {
                    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(30, 0, 0), fractionOfJourney);
                    startTime = Time.time;
                }
                else if (other.transform.position.x > this.transform.position.x)
                {
                    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-30, 0, 0), fractionOfJourney);
                    startTime = Time.time;
                }
                //muda o lado do sprite durante a fuga
                if (other.transform.position.x > gameObject.transform.position.x)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    animator.SetBool("Andando", true);
                    startTime = Time.time;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    animator.SetBool("Andando", true);
                    startTime = Time.time;
                }
            }

            else if(estado ==3)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                if (transform.position != target.position)
                {
                    animator.SetBool("Andando", true);

                }
                else
                {
                    animator.SetBool("Andando", false);
                }
                if (other.transform.position.x > gameObject.transform.position.x)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }

            }
        }
    }
    public void Interagindo(bool interakall)
    {
        mexer = interakall;
        normal = false;
        c = gameObject.transform.position;
        startTime = Time.time;
    }
}
