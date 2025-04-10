using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCrontrol : MonoBehaviour
{
    Scene scene;

    public npcGeral[] npcs;
    public int estado, sprite;
    public Persoangem persona;
    public void setaIsso(int estado, int sprite)
    {
        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i].sprite = sprite;
            npcs[i].estado = estado;

        }
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        setaIsso(estado, sprite);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        setaIsso(estado ,sprite);
    }
     void Update()
    {
        if (scene.name == "Cena2")
        {
            if (persona.Estado == 2)
            {
                setaIsso(1, 2);
            }
            else
            {
                setaIsso(3, 3);
               
            }
        }
        if(scene.name == "Cena3")
        {
            if(persona.Estado == 1)
            {
                setaIsso(1, 1);
            }
            else
            {
                setaIsso(1,0);
            }
        }
        if(scene.name == "Cena4")
        {
            if(persona.Estado == 3)
            {
                setaIsso(1, 4);
            }
            else
            {
                setaIsso(2, 5);
            }
        }
    }
}
