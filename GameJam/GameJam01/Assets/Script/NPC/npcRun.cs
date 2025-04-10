using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcRun : MonoBehaviour
{
    Vector3 a, b, c;
    public GameObject fim;
    public float speed = 1.0F;
    private float startTime; // tempo real
    private float journeyLength;
    private bool ativo = true;
    private bool mexer = true;
    private bool normal = true;
    private bool Ai = true; //ativo interaçao
    float fractionOfJourney;
    float distCovered;
    public Animator Triangulo;

    //Posição que ele está olhando
    private float posAnt, posAtu;

    private int collisionCount = 0;
    void Start()
    {
        a = gameObject.transform.position;
        b = fim.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(a, b);

        Triangulo = GetComponent<Animator>();


    }

    void Update()
    {
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
        if (mexer == true)
        {
            distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / journeyLength;
            if (normal)
            {
                if (ativo)
                {
                    transform.position = Vector3.Lerp(a, b, fractionOfJourney);
                    Triangulo.SetBool("Idle", false);
                }
                else
                {
                    transform.position = Vector3.Lerp(b, a, fractionOfJourney);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        collisionCount++;
        Triangulo.SetBool("Idle", false);
        startTime = Time.time;

    }

    void OnTriggerExit2D(Collider2D col)
    {
        collisionCount--;
        Triangulo.SetBool("Idle", true);
        startTime = Time.time;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
            mexer = false;
            distCovered = (Time.time - startTime) * 4;
            fractionOfJourney = distCovered / journeyLength;
            if (other.transform.position.x< this.transform.position.x)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position+new Vector3(30,0,0) , fractionOfJourney);
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
                startTime = Time.time;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                startTime = Time.time;
            }
        }
    }
    
}
