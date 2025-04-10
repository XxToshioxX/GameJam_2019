using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo_Azul : MonoBehaviour
{
    public GameObject a, b;
    public Persoangem player;
    private void Update()
    {
        if(player.Estado == 1)
        {
            a.SetActive(true);
            b.SetActive(false);
        }
        else
        {
            a.SetActive(false);
            b.SetActive(true);
        }
    }

}
