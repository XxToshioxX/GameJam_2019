﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tela : MonoBehaviour
{
   
    public void carregaCena(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void Sair()
    {
        Application.Quit();
    }

}
