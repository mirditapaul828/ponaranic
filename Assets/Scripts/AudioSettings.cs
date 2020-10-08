using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string MasterVolumePref = "MasterVolumePref";
    private float MasterVolumeFloat;
    public AudioSource[] MasterVolumeAudio;

    void Awake() {
        ContinueSettings();
    }

    private void ContinueSettings() {

        MasterVolumeFloat = PlayerPrefs.GetFloat(MasterVolumePref);

        for (int i = 0; i < MasterVolumeAudio.Length; i++)
        {
            MasterVolumeAudio[i].volume = MasterVolumeFloat;
        }
    }
}
