using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [SerializeField] VolumSO _BackgroundVolume;
    [SerializeField] VolumSO _SFXVolume;
    [SerializeField] private Slider backgroundSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private AudioSource background_Audio;
    [SerializeField] private AudioSource sfx_Audio;

    [SerializeField] private AudioClip backgroundMp3;
    [SerializeField] private List<AudioClip> sfx_Sounds;

    private void Start()
    {
            background_Audio.volume = _BackgroundVolume.volume;
            sfx_Audio.volume = _SFXVolume.volume;
        if(backgroundSlider != null)
        {
            backgroundSlider.value = _BackgroundVolume.volume;
        }

        if(sfxSlider != null)
        {
            sfxSlider.value= _SFXVolume.volume;
        }

        PlaySoundBackground();
    }

    private void PlaySoundBackground()
    {
        background_Audio.loop = true;
        background_Audio.clip = backgroundMp3;
        background_Audio.Play();
    }

    public void Playsound_effect(int index)
    {
        sfx_Audio.PlayOneShot(sfx_Sounds[index]);
    }

    public void MuteBackground()
    {
        background_Audio.mute = !background_Audio.mute;
    }

    public void MuteSFX()
    {
        sfx_Audio.mute = !sfx_Audio.mute;
    }

    public void BackgroundVolume()
    {
        background_Audio.volume = backgroundSlider.value;
    }

    public void SFXVolume()
    {
        background_Audio.volume = sfxSlider.value;
    }
}
