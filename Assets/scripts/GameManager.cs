using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI textoEsferas;
    public TextMeshProUGUI textoMensagem; 
    public int esferasParaVencer = 5;
    public int nivelAtual = 1;
    private int contador = 0;

    void Awake() 
    { 
        instance = this; 
    }

    void Start() 
    { 
        textoMensagem.text = ""; 
    }

    public void AdicionarEsfera()
    {
        contador++;
        textoEsferas.text = "Esferas: " + contador + " / " + esferasParaVencer;

        if (contador >= esferasParaVencer)
        {
            ProximoNivel();
        }
    }

    void ProximoNivel()
    {
        nivelAtual++;
        esferasParaVencer += 5; 
        contador = 0;
        
        textoEsferas.text = "Esferas: 0 / " + esferasParaVencer;
        textoMensagem.text = "NÍVEL " + nivelAtual + "! MAIS ESFERAS!";
        
        // Aqui usamos a versão atualizada e sem avisos do Unity
        FindAnyObjectByType<GeradorEsferas>().GerarEsferas(esferasParaVencer);
        
        Invoke("LimparMensagem", 3f);
    }

    void LimparMensagem() 
    { 
        textoMensagem.text = ""; 
    }
}