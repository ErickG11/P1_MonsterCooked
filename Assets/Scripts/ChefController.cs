using UnityEngine;

public class ChefMovement : MonoBehaviour
{
    public float velocidad = 5f; // Puedes ajustar esta velocidad desde el Inspector

    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal"); // Flechas o A/D
        transform.Translate(Vector2.right * movimiento * velocidad * Time.deltaTime);
    }
}
