using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Animal : MonoBehaviour {

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;

    public void Awake() {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
    }
    
    public void collect() {
        float destructionDelay = audioSource.clip.length + 0.1f;
        audioSource.Play();
        spriteRenderer.enabled = false;
        collider2d.enabled = false;
        Destroy(gameObject, destructionDelay);
    }

}
