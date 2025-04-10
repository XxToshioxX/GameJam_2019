using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator faded;
    public Transform LocalTeleporte;
    private GameObject personagem;
    public int telep;
    public void Start()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D col)
    {             
        if (col.CompareTag("Player"))
        {
            personagem = col.gameObject;
            faded.SetTrigger("Trade");
           StartCoroutine("Tempo");
       
        }
       
    }
    
    public void teleport()
    {

        SceneManager.LoadScene(telep);
        faded.SetTrigger("Trade");
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(1);
        teleport();

    }
}
