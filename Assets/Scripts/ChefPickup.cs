using UnityEngine;

public class Chef : MonoBehaviour
{
    public Transform ingredienteFuente; 
    public Transform lugarIngredienteEnMano; 

    private GameObject ingredienteActual; // El ingrediente que lleva el chef.
    private bool tieneIngrediente = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!tieneIngrediente && ingredienteFuente != null)
            {
                CogerIngrediente();
            }
            else if (tieneIngrediente)
            {
                DejarIngrediente();
            }
        }
    }

    void CogerIngrediente()
    {
        ingredienteActual = Instantiate(ingredienteFuente.gameObject, lugarIngredienteEnMano.position, Quaternion.identity);
        ingredienteActual.transform.SetParent(lugarIngredienteEnMano); // Hacemos hijo para que se mueva con el chef
        tieneIngrediente = true;
    }

    void DejarIngrediente()
    {
        ingredienteActual.transform.SetParent(null); 
        ingredienteActual.transform.position = new Vector3(transform.position.x, -8.6f, 0); // Lo deja justo en el Y deseado, y en su X actual
        ingredienteActual = null;
        tieneIngrediente = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ingrediente"))
        {
            ingredienteFuente = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ingrediente") && other.transform == ingredienteFuente)
        {
            ingredienteFuente = null;
        }
    }
}
