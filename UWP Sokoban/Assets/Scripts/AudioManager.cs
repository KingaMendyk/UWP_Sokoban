using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;
    
    [SerializeField] private AudioSource sfxAudioSource;
    
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void PlaySound(AudioClip clip) {
        sfxAudioSource.clip = clip;
        sfxAudioSource.Play();
    }
}
