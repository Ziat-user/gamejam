using UnityEngine;

public class playBGM : MonoBehaviour
{

    public AudioClip bgm;   // çƒê∂Ç∑ÇÈBGM
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.loop = true;   // ÉãÅ[Évçƒê∂
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
