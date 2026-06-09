using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Configurações do Menu")]
    public GameObject painelinstrucoes; 

    // Função para iniciar o jogo
    public void Jogar() 
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    // Função para fechar o jogo
    public void Sair() 
    {
        Application.Quit();
    }

    // Função que liga/desliga o texto de instruções
    public void MostrarInstrucoes() 
    {
        if (painelinstrucoes != null)
        {
            // Inverte o estado: se está ativo, desativa; se está inativo, ativa.
            painelinstrucoes.SetActive(!painelinstrucoes.activeSelf);
            Debug.Log("Instruções alternadas com sucesso!");
        }
        else
        {
            Debug.LogError("ERRO: Você esqueceu de arrastar o objeto 'painelInstrucoes' no Inspector do Canvas!");
        }
    }
}