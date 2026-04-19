using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 ejesDeRotacion = new Vector3(0, 1, 0);
    [SerializeField] private float velocidadRotacion = 50f;

    void Update()
    {
        // Rota el objeto sobre sí mismo cada frame
        transform.Rotate(ejesDeRotacion * velocidadRotacion * Time.deltaTime);
    }
}
