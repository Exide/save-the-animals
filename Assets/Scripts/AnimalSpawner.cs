using UnityEngine;

public class AnimalSpawner : MonoBehaviour {

    private Camera mainCamera;
    
    public void Awake() {
        mainCamera = Camera.main;
    }
    
    public void spawnAnimals(Animal animal, int count) {
        for (int i = 0; i < count; i++) {
            float x = Random.Range(0, Screen.width - 128);
            float y = Random.Range(0, Screen.height - 128);
            Vector2 screenPoint = new Vector2(x, y);
            Vector2 worldPoint = mainCamera.ScreenToWorldPoint(screenPoint);
            spawnAnimal(animal, worldPoint);
        }
    }
    private void spawnAnimal(Animal animal, Vector2 position) {
        Vector3 position3D = position;
        position3D.z = 1;

        Instantiate(animal, position3D, Quaternion.identity);
    }

}
