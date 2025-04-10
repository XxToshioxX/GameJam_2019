using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tempo : MonoBehaviour
{
    public static Tempo instanceRef;

    public Text Timer;
    public float tempo;
    public float minutos;
    public float segundos;
    public GameObject Tela;

    private void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instanceRef != this)
            Destroy(gameObject);
    }

    void Start()
    {
    
        Scene scene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(this.gameObject);
        if(scene.name !="Menu")
        {
            Tela.SetActive(false);
        }


    }

   
    void Update()
    {

        tempo += Time.deltaTime;
        minutos = Mathf.Floor(tempo / 60);
        segundos = Mathf.Floor(tempo % 60);


        Timer.text = "" + minutos + ":" + segundos;

    }
}
