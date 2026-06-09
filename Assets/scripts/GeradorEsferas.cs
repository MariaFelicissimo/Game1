using UnityEngine;

public class GeradorEsferas : MonoBehaviour
{
    public GameObject prefabEsfera;
    public float raioDeGeracao = 45f;

    void Start() { GerarEsferas(5); }

    public void GerarEsferas(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-raioDeGeracao, raioDeGeracao), 1, Random.Range(-raioDeGeracao, raioDeGeracao));
            Instantiate(prefabEsfera, pos, Quaternion.identity);
        }
    }
}