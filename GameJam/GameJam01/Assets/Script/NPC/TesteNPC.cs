using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteNPC : MonoBehaviour
{
    Vector3 a, b, c;
    public GameObject fim;
    public float speed = 1.5F;
    private float startTime; // tempo real
    private float journeyLength;
    private bool ativo = true;
    private bool mexer = true;
    private bool normal = true;
    private bool Ai = true; //ativo interaçao
    float fractionOfJourney;
    float distCovered;

    private Animator animator;

    //Posição que ele está olhando
    private float posAnt, posAtu;

    private int collisionCount = 0;

    public bool IsNotColliding
    {
        get { return collisionCount == 0; }
    }

    private Transform target;

    public GameObject tar;

    void Start()
    {
        animator = GetComponent<Animator>();
        posAtu = gameObject.transform.position.x;
        posAnt = posAtu;
        target = tar.GetComponent<Transform>();

        a = gameObject.transform.position;
        b = fim.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(a, b);

    }

    // Update is called once per frame
    void Update()
    {

        if(collisionCount < 1)
        {
            Meexer();
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
    

    void OnTriggerEnter2D(Collider2D col)
    {
        collisionCount++;
              
    }

    void OnTriggerExit2D(Collider2D col)
    {
        collisionCount--;
      
           
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (transform.position != target.position)
            {
                animator.SetBool("Interagindo", false);
            }
            else
            {
                animator.SetBool("Interagindo", true);
            }
            if(collision.transform.position.x>gameObject.transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            
        }

    }

    void Meexer()
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
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                startTime = Time.time;
                ativo = false;
                normal = true;
                Ai = false;

            }

            if (transform.position == a)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                startTime = Time.time;
                ativo = true;
                normal = true;
                Ai = true;
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
