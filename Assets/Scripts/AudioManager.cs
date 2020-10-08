using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static readonly string FirstPlay = "FirstPlay";
    private static readonly string MasterVolumePref = "MasterVolumePref";
    private int firstPlayInt;
    public Slider MasterVolumeSlider;
    private float MasterVolumeFloat;
    public AudioSource[] MasterVolumeAudio;
        
    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            MasterVolumeFloat = .75f;
            MasterVolumeSlider.value = MasterVolumeFloat;
            PlayerPrefs.SetFloat(MasterVolumePref, MasterVolumeFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }

        else {
            MasterVolumeFloat = PlayerPrefs.GetFloat(MasterVolumePref);
            MasterVolumeSlider.value = MasterVolumeFloat;
        }
    }

    public void SaveSoundSettings() {
        PlayerPrefs.SetFloat(MasterVolumePref, MasterVolumeSlider.value);
    }

    void OnApplicationFocus(bool inFocus) {
        if (!inFocus) {
            SaveSoundSettings();
        }
    }

    public void UpdateSound() {

        for (int i = 0; i < MasterVolumeAudio.Length; i++) {
            MasterVolumeAudio[i].volume = MasterVolumeSlider.value;
        }
    }
}
