using UnityEngine;
using UnityEngine.SceneManagement;

public class ChefPickup : MonoBehaviour
{
    public Transform ingredienteEnMano;
    private GameObject ingredienteActual;

    public PedidoManager pedidoManager; // Arrástralo en el Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ingredienteActual == null) CogerIngrediente();
            else SoltarIngrediente();
        }

        if (Input.GetKeyDown(KeyCode.R) && ingredienteActual != null)
        {
            // Nombre limpio de lo que tenemos en la mano
            string entregado = ingredienteActual.name
                .Replace("(Clone)", "").Trim();

            // Pedido activo desde PedidoManager
            string pedido = pedidoManager.ObtenerPedidoActual();

            // Solo sumamos si coincide exactamente el nombre
            if (entregado.Equals(pedido, System.StringComparison.OrdinalIgnoreCase))
            {
                pedidoManager.VerificarPedido(pedido);
                // Aquí podrías reproducir un sonido o animación de acierto
            }
            else
            {
                // Entrega incorrecta: no sumamos y podemos resetear indicador de pedido
                // (Opcional) pedidoManager.ResetPedido(); 
                // No hay logs ni cambio de escena
            }

            // Siempre destruimos lo que estaba en la mano
            Destroy(ingredienteActual);
            ingredienteActual = null;
        }
    }

    void CogerIngrediente()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1.5f);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Ingrediente"))
            {
                GameObject seleccionado = hit.gameObject;
                GameObject clone;

                if (!seleccionado.name.Contains("(Clone)"))
                    clone = Instantiate(seleccionado);
                else
                    clone = seleccionado;

                clone.transform.position = ingredienteEnMano.position;
                clone.transform.SetParent(ingredienteEnMano);
                ingredienteActual = clone;
                break;
            }
        }
    }

    void SoltarIngrediente()
    {
        ingredienteActual.transform.SetParent(null);
        ingredienteActual.transform.position = new Vector3(
            transform.position.x, -8.6f, 0
        );
        ingredienteActual = null;
    }
}
