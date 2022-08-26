using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontrarElementoEnArray : MonoBehaviour
{
    //1. Crear array publico de gameobjects
    public GameObject[] arrayDeMesas;
    // Start is called before the first frame update
    void Start()
    {
        //2. Asignar todos los objetos tageados como "Mesa" al array
        arrayDeMesas = GameObject.FindGameObjectsWithTag("Mesa");
        AddMesaScriptAndSetDestructible();
    }

    // Update is called once per frame
    void Update()
    {
        //4. Invocar la funcion al presionar el 0.
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //DeactivateObjectsInArray();
            DestroyDestructible();
        }
    }

    //3. Crear una funcion que desactive todos los elementos del array
    void DeactivateObjectsInArray()
    {
        for (int i = 0; i < arrayDeMesas.Length; i++)
        {
            arrayDeMesas[i].SetActive(false);
        }
    }

    //5. Crear una funcion que asigne a todos los elementos del array el script mesa.
    // Establecer el valor de la variable "destructible" aleatoriamente.

    void AddMesaScriptAndSetDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {
            go.AddComponent<Mesa>();
            go.GetComponent<Mesa>().destructible = Random.Range(0, 2) == 0;
            
        }
    }

    //6. Crear una funcion que destruya el elemento del array que contenga un Script "Mesa"
    // cuya variable booleana "destructible" sea true.
    void DestroyDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {

            if (go.GetComponent<Mesa>().destructible)
            {
                Destroy(go);
            } 
        }
    }
}
