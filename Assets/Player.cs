using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10;
    public int points = 0;
    
    private void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y);
        float distance = speed * Time.deltaTime;
        transform.Translate(direction * distance);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.name.StartsWith("Animal")) return;

        Animal animal = other.gameObject.GetComponent<Animal>();
        // todo: get the point value from the animal
        points += 1;
        
        animal.collect();
    }

}
