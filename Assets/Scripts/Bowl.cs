using UnityEngine;
using System.Collections.Generic;

public class Bowl : MonoBehaviour
{
    public GameObject ensaladaPrefab; // Asigna el prefab desde el Inspector
    private List<GameObject> ingredientesEnBowl = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            VerificarIngredientesYFusionar();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ingrediente") && !ingredientesEnBowl.Contains(other.gameObject))
        {
            ingredientesEnBowl.Add(other.gameObject);
        }
    }

    void VerificarIngredientesYFusionar()
    {
        // Primero limpiamos referencias nulas por seguridad
        ingredientesEnBowl.RemoveAll(item => item == null);

        bool hayTomate = false;
        bool hayLechuga = false;

        // Revisamos qué ingredientes hay
        foreach (GameObject ing in ingredientesEnBowl)
        {
            string nombre = ing.name.ToLower();
            if (nombre.Contains("tomate")) hayTomate = true;
            if (nombre.Contains("lechuga")) hayLechuga = true;
        }

        // Si hay ambos, fusionamos
        if (hayTomate && hayLechuga)
        {
            foreach (GameObject ing in new List<GameObject>(ingredientesEnBowl))
            {
                if (ing != null) Destroy(ing);
            }

            ingredientesEnBowl.Clear(); // Vaciar para aceptar nuevos ingredientes

            // Crear la nueva ensalada
            GameObject nuevaEnsalada = Instantiate(ensaladaPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            nuevaEnsalada.tag = "Ingrediente"; // Para que el chef pueda recogerla
        }
    }
}
