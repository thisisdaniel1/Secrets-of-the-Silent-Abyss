using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager audioManager;

    [SerializeField]
    private AudioSource audioSource;

    private static AudioManager instance;

    public static AudioManager Instance{
        get{
            if (instance == null){
                instance = FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }

    void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
    }

    public void Play(AudioClip audioClip){
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
