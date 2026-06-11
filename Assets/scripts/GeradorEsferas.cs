using UnityEngine;

public class GeradorEsferas : MonoBehaviour
{
    public GameObject prefabEsfera;
    public float raioDeGeracao = 45f;

    void Start()
    {
        GerarEsferas(GameManager.instance.esferasParaVencer);
    }

    public void GerarEsferas(int quantidade)
    {
        // Destrói esferas que sobraram da fase anterior
        foreach (var esfera in FindObjectsByType<Coletavel>(FindObjectsSortMode.None))
            Destroy(esfera.gameObject);

        for (int i = 0; i < quantidade; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-raioDeGeracao, raioDeGeracao),
                1,
                Random.Range(-raioDeGeracao, raioDeGeracao)
            );
            Instantiate(prefabEsfera, pos, Quaternion.identity);
        }
    }
}