using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PedidoManager : MonoBehaviour
{
    public TextMeshProUGUI textoPedido;
    public float tiempoEntrePedidos = 10f;

    private string pedidoActual = "";
    private string[] posiblesPedidos;

    void Start()
    {
        // 1) Elige el set de pedidos según la escena
        string scene = SceneManager.GetActiveScene().name;
        if (scene == "SampleScene")
        {
            posiblesPedidos = new string[] { "Tomate", "Lechuga", "Ensalada" };
        }
        else if (scene == "SegundoNivel")
        {
            posiblesPedidos = new string[]
            {
                "Hamburguesa Simple",
                "Cheese Burguer",
                "Hamburguesa Completa"
            };
        }
        else
        {
            // Por si más escenas
            posiblesPedidos = new string[0];
        }

        StartCoroutine(GenerarPedidos());
    }

    IEnumerator GenerarPedidos()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntrePedidos);
            if (posiblesPedidos.Length == 0) continue;

            pedidoActual = posiblesPedidos[Random.Range(0, posiblesPedidos.Length)];
            textoPedido.text = "Pedido: " + pedidoActual;
        }
    }

    public void VerificarPedido(string item)
    {
        switch (item)
        {
            case "Ensalada":
                ScoreManager.Instance.AgregarPuntos(20);
                break;
            case "Tomate":
            case "Lechuga":
                ScoreManager.Instance.AgregarPuntos(15);
                break;
            case "Hamburguesa Simple":
                ScoreManager.Instance.AgregarPuntos(25);
                break;
            case "Cheese Burguer":
                ScoreManager.Instance.AgregarPuntos(30);
                break;
            case "Hamburguesa Completa":
                ScoreManager.Instance.AgregarPuntos(40);
                break;
        }

        // Comprueba si ya llegó al máximo
        if (ScoreManager.Instance.ObtenerScore() >= ScoreManager.Instance.scoreMaximo)
            Debug.Log("🎉 ¡Nivel completado!");
    }

    public string ObtenerPedidoActual()
    {
        return pedidoActual;
    }
}
