using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10;
    public int points = 0;
    
    private void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(x, y) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Player triggered by " + other.gameObject.name);
        if (other.gameObject.name.StartsWith("Animal")) {
            points++;
            Animal animal = other.gameObject.GetComponent<Animal>();
            animal.gather();
        }
    }

}
