using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void set_volume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
