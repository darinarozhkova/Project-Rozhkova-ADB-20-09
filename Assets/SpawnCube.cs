using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject cubePrefab;

    public void Start()
    {
        EventsController.ManufactorCycle += GenerateCube;

        GenerateCube();
    }

    public void GenerateCube()
    {
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}
