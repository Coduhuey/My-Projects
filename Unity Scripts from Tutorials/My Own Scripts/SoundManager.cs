using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource efxSource;
    public AudioSource musicSource;

    public static SoundManager instance = null;


    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;
    
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); //that way, background sound doesn't restart once the level ends and the past loaded level is destroyed
	}

    public void PlaySingle (AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips) //can send many audioclips, as long as seperated with a comma
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randompitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randompitch;
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
    }
	
}
