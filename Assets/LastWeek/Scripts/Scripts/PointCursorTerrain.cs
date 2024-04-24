using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCursorTerrain : MonoBehaviour
{
    public Transform cursor3D;
    void Update()
    {
        // Verifica si se ha hecho clic con el bot�n izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Lanza un rayo desde la posici�n del clic del mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verifica si el rayo colisiona con algo
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica si la colisi�n es con el terreno (asumiendo que el terreno tiene una capa llamada "Terrain")
                if (hit.collider.CompareTag("Terrain"))
                {
                    // La colisi�n ocurri� en el terreno
                    Debug.Log("Colisi�n con el terreno en: " + hit.point);
                    cursor3D.position = hit.point;
                }
            }
        }
    }
}
