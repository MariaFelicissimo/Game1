using UnityEngine;
using UnityEngine.SceneManagement;

public class Coletavel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na esfera tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Você coletou uma esfera!");
            Destroy(gameObject); // Isso deleta a esfera da cena ao tocar nela
        }
        if (other.CompareTag("Player")){
        GameManager.instance.AdicionarEsfera(); // AVISA O GERENCIADOR
        Destroy(gameObject);
        }
    }
}