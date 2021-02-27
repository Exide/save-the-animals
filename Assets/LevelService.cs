using System.Collections.Generic;
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

    private List<Color> availableBackgroundColors = new List<Color> {
        Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow
    };

    private Camera mainCamera;

    public void Start() {
        mainCamera = Camera.main;
        mainCamera.backgroundColor = pickRandomColor();
        spawnAnimalsForLevel();
    }

    public void Update() {
        int animalsSpawned = GameObject.FindGameObjectsWithTag("Animal").Length;
        if (animalsSpawned > 0) return;

        goToNextLevel();
        spawnAnimalsForLevel();
    }

    private void goToNextLevel() {
        mainCamera.backgroundColor = pickRandomColor();
        currentLevel++;
    }

    private Color pickRandomColor() {
        int count = availableBackgroundColors.Count;
        int pick = Random.Range(0, count - 1);
        Color baseColor = availableBackgroundColors[pick];
        return baseColor * 0.5f;
    }
    
    private void spawnAnimalsForLevel() {
        int animalCount = currentLevel * animalsPerLevelMultiplier;
        animalSpawner.spawnAnimals(animalToSpawn, animalCount);
    }
    
}
