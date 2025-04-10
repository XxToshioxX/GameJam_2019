using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    Vector3 a, b,c;
    public GameObject fim;
    public float speed = 1.0F;
    private float startTime; // tempo real
    private float journeyLength;
    private bool ativo = true;
    private bool mexer = true;
    private bool normal = true;
    private bool Ai = true; //ativo interaçao

    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.position;
        b = fim.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(a, b);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (mexer == true)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
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
    public void Interagindo(bool interakall)
    {
        mexer = interakall;
        normal = false;
        c = gameObject.transform.position;
        startTime = Time.time;

    }

}
