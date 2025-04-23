using UnityEngine;

public class ChefPickup : MonoBehaviour
{
    public Transform ingredienteEnMano;
    private GameObject ingredienteActual;

    public PedidoManager pedidoManager; // Asignar en el Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ingredienteActual == null)
            {
                CogerIngrediente();
            }
            else
            {
                SoltarIngrediente();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && ingredienteActual != null)
        {
            string nombreEntregado = ingredienteActual.name.Replace("(Clone)", "").Trim().ToLower();

            if (nombreEntregado.Contains("tomate"))
                pedidoManager.VerificarPedido("Tomate");
            else if (nombreEntregado.Contains("lechuga"))
                pedidoManager.VerificarPedido("Lechuga");
            else if (nombreEntregado.Contains("ensalada"))
                pedidoManager.VerificarPedido("Ensalada");

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

                if (!seleccionado.name.Contains("(Clone)"))
                {
                    GameObject clone = Instantiate(seleccionado);
                    clone.transform.position = ingredienteEnMano.position;
                    clone.transform.SetParent(ingredienteEnMano);
                    ingredienteActual = clone;
                }
                else
                {
                    seleccionado.transform.position = ingredienteEnMano.position;
                    seleccionado.transform.SetParent(ingredienteEnMano);
                    ingredienteActual = seleccionado;
                }

                break;
            }
        }
    }

    void SoltarIngrediente()
    {
        ingredienteActual.transform.SetParent(null);
        ingredienteActual.transform.position = new Vector3(transform.position.x, -8.6f, 0);
        ingredienteActual = null;
    }
}
