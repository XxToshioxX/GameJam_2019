using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoRun : MonoBehaviour
{
    
    public GameObject balao;

    public npcRun carinha;
    void Start()
    {
        balao.SetActive(false);
      
    }
   
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            balao.SetActive(true);
           // carinha.Interagindo(false);

        }
       
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            balao.SetActive(false);
          //  carinha.Interagindo(true);
        }
    }
}
