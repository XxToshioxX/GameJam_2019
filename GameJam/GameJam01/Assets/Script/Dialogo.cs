using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{

    public Animator animator;
    public string animacao;
    public Persoangem player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.enabled = true;
    }

    public void desativaPlayer()
    {
        player.enabled = false;
    }
    public void ativaPlayer()
    {
        player.enabled = true;
    }
}
