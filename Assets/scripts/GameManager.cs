using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI textoEsferas;
    public TextMeshProUGUI textoMensagem;
    public int esferasParaVencer = 10;
    public int nivelAtual = 1;
    private int contador = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        textoMensagem.text = "";
        textoEsferas.text = "Esferas: 0 / " + esferasParaVencer;
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
        int aumento = Random.Range(3, 7); // 3 a 6 a mais por fase
        esferasParaVencer += aumento;
        contador = 0;

        textoEsferas.text = "Esferas: 0 / " + esferasParaVencer;
        textoMensagem.text = "NÍVEL " + nivelAtual + "! +" + aumento + " ESFERAS!";

        FindAnyObjectByType<GeradorEsferas>().GerarEsferas(esferasParaVencer);

        Invoke("LimparMensagem", 3f);
    }

    void LimparMensagem()
    {
        textoMensagem.text = "";
    }
}