using UnityEngine;

public class AnimalSpawner : MonoBehaviour {

    private Camera mainCamera;

    public void Awake() {
        mainCamera = Camera.main;
    }

    public void spawnAnimals(Animal animal, int count) {
        // GameObject player = GameObject.FindWithTag("Player");
        // Collider2D playerCollider = player.GetComponent<Collider2D>();
        Sprite animalSprite = animal.GetComponent<SpriteRenderer>().sprite;

        for (int i = 0; i < count; i++) {
            Vector2 spawnPoint = findAvailableSpawnPoint(animalSprite);
            // Vector2 spawnPoint = findAvailableSpawnPoint(animalSprite, playerCollider);
            spawnAnimal(animal, spawnPoint);
        }
    }

    private Vector2 findAvailableSpawnPoint(Sprite animalSprite) {
        float xBuffer = animalSprite.texture.width;
        float yBuffer = animalSprite.texture.height;
        float x = Random.Range(0 + xBuffer, Screen.width - xBuffer);
        float y = Random.Range(0 + yBuffer, Screen.height - yBuffer);
        Vector2 screenPoint = new Vector2(x, y);
        return mainCamera.ScreenToWorldPoint(screenPoint);
    }

    private Vector2 findAvailableSpawnPoint(Sprite animalSprite, Collider2D playerCollider) {
        Vector2 bottomLeft = mainCamera.ScreenToWorldPoint(Vector3.zero);
        Vector2 topRight = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        Vector2 animalSize = new Vector2(animalSprite.texture.width, animalSprite.texture.height);

        bottomLeft += animalSize;
        topRight -= animalSize;
        
        return findPointNotOverlappingPlayer(bottomLeft, topRight, playerCollider);
    }

    private static Vector2 findPointNotOverlappingPlayer(Vector2 bottomLeft, Vector2 topRight, Collider2D playerCollider) {
        Vector2 point;

        // do {
            float x = Random.Range(bottomLeft.x, topRight.x);
            float y = Random.Range(bottomLeft.y, topRight.y);
        point = new Vector2(x, y);
        // } while (playerCollider.OverlapPoint(point));

        return point;
    }

    private void spawnAnimal(Animal animal, Vector2 position) {
        Vector3 position3D = position;
        position3D.z = 1;

        Instantiate(animal, position3D, Quaternion.identity);
    }

}
