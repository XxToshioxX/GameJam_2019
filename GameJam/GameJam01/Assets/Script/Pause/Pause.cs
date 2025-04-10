using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    private bool pausou = true;

    public GameObject Tela;
    public GameObject Botao;
   

    void Start()
    {
        
       
    }

   
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }
    public void Pausar()
    {
        if (pausou)
        {
            Tela.SetActive(true);
            Botao.SetActive(false);
            Time.timeScale = 0f;
            pausou = false;
        }
        else
        {
            Tela.SetActive(false);
            Botao.SetActive(true);
            Time.timeScale = 1f;
            pausou = true;
        }      

    }
    public void Menu(int num)
    {
        SceneManager.LoadScene(num);
        

    }
   
}
