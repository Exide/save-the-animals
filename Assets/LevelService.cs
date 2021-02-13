using UnityEngine;

public class LevelService : MonoBehaviour {

    [SerializeField]
    private AnimalSpawner animalSpawner;

    [SerializeField]
    private Animal animalToSpawn;

    [SerializeField]
    private int animalsPerLevelMultiplier = 3;
    
    [SerializeField]
    private int currentLevel = 1;

    public void Start() {
        spawnAnimalsForLevel();
    }

    public void Update() {
        int animalsSpawned = GameObject.FindGameObjectsWithTag("Animal").Length;
        if (animalsSpawned > 0) return;

        currentLevel++;
        spawnAnimalsForLevel();
    }

    private void spawnAnimalsForLevel() {
        int animalCount = currentLevel * animalsPerLevelMultiplier;
        animalSpawner.spawnAnimals(animalToSpawn, animalCount);
    }
    
}
