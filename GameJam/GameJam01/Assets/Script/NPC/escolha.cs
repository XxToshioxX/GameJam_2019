using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escolha : MonoBehaviour
{
    Scene scene;
    public SpriteRenderer escolha1;
    public SpriteRenderer escolha2;  
    public SpriteRenderer escolha3;
    public SpriteRenderer escolha4;

    public bool desativoA,desativoB ;

    public Color Cor1,Cor2,Cor3,Cor4;
    public Persoangem personagem;
    public bool ativo;

    public int indx;

    public void Start()
    {
      

        scene = SceneManager.GetActiveScene();
        escolha1.enabled = false;
        escolha2.enabled = false;
        escolha3.enabled = false;
        escolha4.enabled = false;
        ativo = false;
    }

   

    public void OnTriggerExit2D(Collider2D collision)
    {
        escolha1.enabled = false;
        escolha2.enabled = false;
        escolha3.enabled = false;
        escolha4.enabled = false;
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            escolha1.enabled = true;
            escolha2.enabled = true;
            escolha3.enabled = true;
            escolha4.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!ativo)
                {
                    col.GetComponent<Persoangem>().enabled = false;
                    indx = 1;
                    ativo = true;
                }
                else
                {
                    col.GetComponent<Persoangem>().enabled = true;
                    if(indx == 1)
                    {
                        personagem.Estado = 0;
                        GameObject.Find("PauseMenuUpdate").GetComponent<PlayerManager>().AtualizaEstado(); // Roxo
                        this.gameObject.SetActive(false);

                    }
                    if (indx == 2)
                    {
                        personagem.Estado = 1;
                        GameObject.Find("PauseMenuUpdate").GetComponent<PlayerManager>().AtualizaEstado(); //Azul
                        this.gameObject.SetActive(false);

                    }
                    if (indx == 3)
                    {
                        personagem.Estado = 2;
                        GameObject.Find("PauseMenuUpdate").GetComponent<PlayerManager>().AtualizaEstado(); //Vermelho
                        this.gameObject.SetActive(false);

                    }
                    if (indx == 4)
                    {
                        personagem.Estado = 3;
                        GameObject.Find("PauseMenuUpdate").GetComponent<PlayerManager>().AtualizaEstado(); // Amarelo
                        this.gameObject.SetActive(false);

                    }
                    this.gameObject.SetActive(false);
                   
                }
                
            }
            if (ativo)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {                   
                        indx = 3;                    
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && desativoA == false)
                {
                    indx = 2;

                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {               
                        indx = 1;                                      
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) && desativoB == false)
                {
                    indx = 4;

                }
            }
            if (indx == 1)
            {


                Cor1 = escolha1.color;
                Cor1.a = 1f;
                escolha1.color = Cor1;

                Cor2 = escolha2.color;
                Cor2.a = 0.5f;
                escolha2.color = Cor2;

                Cor3 = escolha3.color;
                Cor3.a = 0.5f;
                escolha3.color = Cor3;

                Cor4 = escolha4.color;
                Cor4.a = 0.5f;
                escolha4.color = Cor4;

            }
             if (indx == 2)
            {


                Cor1 = escolha1.color;
                Cor1.a = 0.5f;
                escolha1.color = Cor1;

                Cor2 = escolha2.color;
                Cor2.a = 1;
                escolha2.color = Cor2;

                Cor3 = escolha3.color;
                Cor3.a = 0.5f;
                escolha3.color = Cor3;

                Cor4 = escolha4.color;
                Cor4.a = 0.5f;
                escolha4.color = Cor4;

            }
             if (indx == 3)
            {

                Cor1 = escolha1.color;
                Cor1.a = 0.5f;
                escolha1.color = Cor1;

                Cor2 = escolha2.color;
                Cor2.a = 0.5f;
                escolha2.color = Cor2;

                Cor3 = escolha3.color;
                Cor3.a = 1;
                escolha3.color = Cor3;

                Cor4 = escolha4.color;
                Cor4.a = 0.5f;
                escolha4.color = Cor4;

            }
            if (indx == 4)
            {

                Cor1 = escolha1.color;
                Cor1.a = 0.5f;
                escolha1.color = Cor1;

                Cor2 = escolha2.color;
                Cor2.a = 0.5f;
                escolha2.color = Cor2;

                Cor3 = escolha3.color;
                Cor3.a = 0.5f;
                escolha3.color = Cor3;

                Cor4 = escolha4.color;
                Cor4.a = 1;
                escolha4.color = Cor4;

            }



        }
    }
}
