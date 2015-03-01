using UnityEngine;
using System.Collections;

public class SoundEffectScript : MonoBehaviour {

    public static SoundEffectScript Instance;

    public AudioClip banana_foomp;
    public AudioClip banana_splat;
    public AudioClip fillette_ahahahah;
    public AudioClip fillette_ohnon;
    public AudioClip game_over;
    public AudioClip growl_01;
    public AudioClip growl_02;
    public AudioClip growl_03;
    public AudioClip growl_04;
    public AudioClip next_wave;
    public AudioClip tower_fwiiiin;
    public AudioClip tower_rawr;
    
    // etc...

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsScript!");
        }
        Instance = this;
    }

    public void MakeBanana_foompSound() {
        MakeSound(banana_foomp);
    }

    public void MakeBanana_splatSound() {
        MakeSound(banana_splat);
    }

    public void MakeFillette_ahahahahSound()
    {
        MakeSound(fillette_ahahahah);
    }

    public void MakeFillette_ohnonSound()
    {
        MakeSound(fillette_ohnon);
    }

    public void MakeGame_overSound()
    {
        MakeSound(game_over);
    }

    public void MakeGrowl_1Sound()
    {
        MakeSound(growl_01);
    }

    public void MakeGrowl_2Sound()
    {
        MakeSound(growl_02);
    }

    public void MakeGrowl_3Sound()
    {
        MakeSound(growl_03);
    }

    public void MakeGrowl_4Sound()
    {
        MakeSound(growl_04);
    }

    public void MakeNext_waveSound()
    {
        MakeSound(next_wave);
    }

    public void Maketower_fwiiiinSound()
    {
        MakeSound(tower_fwiiiin);
    }

    public void MakeTower_rawrSound()
    {
        MakeSound(tower_rawr);
    }


    // Play a given sound
    private void MakeSound(AudioClip originalClip)
    {
        // As it is not 3D audio clip, position doesn't matter.
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
