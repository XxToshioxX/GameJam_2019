using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    public int EstadoJogador;
    Scene scene;

    private void Start()
    {

         scene = SceneManager.GetActiveScene();
    }
    void Update()
    {

       
        if (scene.name != "Menu")
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            mudaVisual();
        }
       
    }
    public void AtualizaEstado()
    {
        EstadoJogador = Player.GetComponent<Persoangem>().Estado;
        
    }
    public void mudaVisual()
    {
        Player.GetComponent<Persoangem>().retornaEstado(EstadoJogador);

    }
}
