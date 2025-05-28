using UnityEngine;
using TMPro; 
using System.Collections;

public class PedidoManager : MonoBehaviour
{
    public TextMeshProUGUI textoPedido; 
    public float tiempoEntrePedidos = 10f;

    private string pedidoActual = "";
    private string[] posiblesPedidos = { "Tomate", "Lechuga", "Ensalada" };

    void Start()
    {
        StartCoroutine(GenerarPedidos());
    }

    IEnumerator GenerarPedidos()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntrePedidos);
            pedidoActual = posiblesPedidos[Random.Range(0, posiblesPedidos.Length)];
            textoPedido.text = "Pedido: " + pedidoActual;
        }
    }

    public void VerificarPedido(string item)
    {
        if (item == "Ensalada")
        {
            ScoreManager.Instance.AgregarPuntos(20);
            Debug.Log("✅ Entregaste una ensalada: +20 puntos");
        }
        else if (item == "Tomate")
        {
            ScoreManager.Instance.AgregarPuntos(5);
            Debug.Log("✅ Entregaste un tomate: +5 puntos");
        }
        else if (item == "Lechuga")
        {
            ScoreManager.Instance.AgregarPuntos(5);
            Debug.Log("✅ Entregaste una lechuga: +5 puntos");
        }

       
        if (ScoreManager.Instance.ObtenerScore() >= 100)
        {
            Debug.Log("🎉 ¡Nivel completado!");
            
        }
    }


    public string ObtenerPedidoActual()
    {
        return pedidoActual;
    }
}
