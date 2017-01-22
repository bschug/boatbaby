using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySoundManager : SingletonMonoBehaviour<BabySoundManager> {

    AudioSource AudioSource;

    public AudioClip[] GiggleSounds;
    public AudioClip[] EatSounds;
    public AudioClip[] YawnSounds;
    public AudioClip[] WhistleSounds;
    public AudioClip[] CheerSounds;
    public AudioClip[] ScaredSounds;
    public AudioClip[] ShySounds;
    public AudioClip[] IdleSounds;
    public AudioClip[] AttachItemSounds;

    protected override void Awake () {
        base.Awake();
        AudioSource = GetComponent<AudioSource>();
    }

    void PlaySoundFromArray (AudioClip[] sounds, float volumeScale = 1f, float pitch = 1.5f) {
        if (sounds.Length == 0) {
            Debug.LogWarning( "No sounds defined!" );
            return;
        }
        AudioSource.pitch = 1.5f;
        AudioSource.PlayOneShot( sounds[Random.Range( 0, sounds.Length )] );
    }

    public void Giggle() {
        PlaySoundFromArray( GiggleSounds );
    }

    public void Eat() {
        PlaySoundFromArray( EatSounds );
    }

    public void Yawn() {
        PlaySoundFromArray( YawnSounds );
    }

    public void Whistle() {
        PlaySoundFromArray( WhistleSounds );
    }

    public void Cheer () {
        PlaySoundFromArray( CheerSounds );
    }

    public void Scared() {
        PlaySoundFromArray( ScaredSounds );
    }

    public void Shy() {
        PlaySoundFromArray( ShySounds );
    }

    public void Idle() {
        PlaySoundFromArray( IdleSounds );
    }

    public void AttachItem() {
        PlaySoundFromArray( AttachItemSounds );
    }
}
