using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao : MonoBehaviour
{
    public GameObject balao;
    public Animator npc;

    public npc carinha;
    void Start()
    {
        balao.SetActive(false);
        npc.GetComponent<Animator>();
    }
   
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            balao.SetActive(true);
            carinha.Interagindo(false);
            npc.SetBool("Interagindo", true);

        }
       
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            balao.SetActive(false);
            carinha.Interagindo(true);
            npc.SetBool("Interagindo", false);
        }
    }
}
