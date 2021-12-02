using Jiufen.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayAudio : MonoBehaviour
{
    public AudioMixer m_audioMixer;

    public AudioMixerSnapshot m_defaultSnapShot;
    public AudioMixerSnapshot m_distortedSnapShot;
    private bool m_isDistorted = false;
    void Update()
    {
        //NormalSnapshot
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_isDistorted = !m_isDistorted;
            if (m_isDistorted)
                m_defaultSnapShot.TransitionTo(0.1f);
            else
                m_distortedSnapShot.TransitionTo(0.1f);
        }

        //Blended
        if (Input.GetKeyDown(KeyCode.R))
        {
            AudioMixerSnapshot[] snapshots = new AudioMixerSnapshot[2] { m_defaultSnapShot, m_distortedSnapShot };
            float[] weights = new float[2] { 0.4f, 0.6f };
            m_audioMixer.TransitionToSnapshots(snapshots,weights,1.0f);
        }
    }

}
