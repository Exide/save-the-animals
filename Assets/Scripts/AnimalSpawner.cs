using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour {

    public int totalAnimals = 1;
    public Object animalToSpawn;

    private void Start() {
        for (int i = 0; i < totalAnimals; i++) {
            spawnAnimalInRandomPosition();
        }
    }

    private void spawnAnimalInRandomPosition() {
        float x = Random.Range(0, Screen.width - 128);
        float y = Random.Range(0, Screen.height - 128);
        float z = 1;

        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
        Instantiate(animalToSpawn, position, Quaternion.identity);
    }

}
