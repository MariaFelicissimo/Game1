using UnityEngine;

public class Coletavel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AdicionarEsfera();
            Destroy(gameObject);
        }
    }
}