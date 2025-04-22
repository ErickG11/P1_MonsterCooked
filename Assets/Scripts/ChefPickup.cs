using UnityEngine;

public class Chef : MonoBehaviour
{
    public GameObject ingrediente; // Ingrediente detectado por colisión
    public Transform IngredienteEnMano; // Posición visual en la "mano" del chef
    private bool tieneIngrediente = false;
    private GameObject ingredienteActual; // Referencia al ingrediente que el chef lleva

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!tieneIngrediente && ingrediente != null)
            {
                CogerIngrediente();
            }
            else if (tieneIngrediente)
            {
                DejarIngrediente();
            }
        }
    }

    private void CogerIngrediente()
    {
        ingredienteActual = ingrediente;
        ingredienteActual.transform.SetParent(IngredienteEnMano); // Lo hace hijo del punto en la mano
        ingredienteActual.transform.localPosition = Vector3.zero; // Lo centra en ese punto
        tieneIngrediente = true;
    }

    private void DejarIngrediente()
    {
        ingredienteActual.transform.SetParent(null); // Quita el ingrediente de la mano
        ingredienteActual.transform.position = transform.position; // Lo deja en la posición del chef
        ingredienteActual = null;
        tieneIngrediente = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ingrediente") && !tieneIngrediente)
        {
            ingrediente = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ingrediente") && other.gameObject == ingrediente)
        {
            ingrediente = null;
        }
    }
}

