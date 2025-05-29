using UnityEngine;
using System.Collections.Generic;

public class BurgerTable : MonoBehaviour
{
    [Header("Prefabs de Hamburguesas")]
    public GameObject simplePrefab;    // Prefab “Hamburguesa Simple”
    public GameObject cheesePrefab;    // Prefab “Cheese Burguer”
    public GameObject completePrefab;  // Prefab “Hamburguesa Completa”

    [Header("Ajustes de Fusión")]
    public float spawnYOffset = 0.5f;    // Altura sobre la mesa al instanciar
    public float desiredScale = 0.5f;    // Escala relativa de la burger

    private List<GameObject> ingredientesEnMesa = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            VerificarIngredientesYFusionar();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ingrediente") && !ingredientesEnMesa.Contains(other.gameObject))
            ingredientesEnMesa.Add(other.gameObject);
    }

    void VerificarIngredientesYFusionar()
    {
        // 1) Limpiar referencias nulas
        ingredientesEnMesa.RemoveAll(i => i == null);

        // 2) Detectar ingredientes
        bool hasPan = ingredientesEnMesa.Exists(i => i.name.ToLower().Contains("pan"));
        bool hasCarne = ingredientesEnMesa.Exists(i => i.name.ToLower().Contains("carne"));
        bool hasQueso = ingredientesEnMesa.Exists(i => i.name.ToLower().Contains("queso"));
        bool hasHuevo = ingredientesEnMesa.Exists(i => i.name.ToLower().Contains("huevo"));
        bool hasVeg = ingredientesEnMesa.Exists(i =>
                            i.name.ToLower().Contains("lettuce") ||
                            i.name.ToLower().Contains("tomate"));

        // 3) Elegir prefab
        GameObject toSpawn = null;
        if (hasPan && hasCarne && hasQueso && hasHuevo && hasVeg)
            toSpawn = completePrefab;
        else if (hasPan && hasCarne && hasQueso)
            toSpawn = cheesePrefab;
        else if (hasPan && hasCarne)
            toSpawn = simplePrefab;

        if (toSpawn == null)
        {
            Debug.LogWarning("BurgerTable: combinación no válida.");
            return;
        }

        // 4) Destruir ingredientes usados
        foreach (var ing in new List<GameObject>(ingredientesEnMesa))
            if (ing != null) Destroy(ing);
        ingredientesEnMesa.Clear();

        // 5) Instanciar hamburguesa
        Vector3 spawnPos = transform.position + Vector3.up * spawnYOffset;
        GameObject burger = Instantiate(toSpawn, spawnPos, Quaternion.identity);

        // 6) Escalarla
        burger.transform.localScale = burger.transform.localScale * desiredScale;

        // 7) Asegurar que tiene Collider2D y Rigidbody2D para poder recogerla
        if (burger.GetComponent<Collider2D>() == null)
            burger.AddComponent<BoxCollider2D>().isTrigger = false;
        if (burger.GetComponent<Rigidbody2D>() == null)
        {
            var rb = burger.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0;
        }

        // 8) Taggear para ChefPickup
        burger.tag = "Ingrediente";

        Debug.Log("BurgerTable: Instanciada → " + toSpawn.name);
    }
}
