using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip BatKill, SkeletonDrag;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        BatKill = Resources.Load<AudioClip>("BatKill");
        SkeletonDrag = Resources.Load<AudioClip>("SkeletonDrag");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        switch (clip) {
            case "Batkill":
                audioSrc.PlayOneShot(BatKill);
                break;
            case "SkeletonDrag":
                audioSrc.PlayOneShot(SkeletonDrag);
                break;
        }
    }
}
