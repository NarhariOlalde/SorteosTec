using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootboxSFX : MonoBehaviour
{

    public AudioClip lootboxwood;
    public AudioClip lootboxchido;
    public AudioClip lootboxoro;
    // Start is called before the first frame update


    // Update is called once per frame
    public void PlaySoundEffectWood() {

        AudioSource.PlayClipAtPoint(lootboxwood, Camera.main.transform.position, 0.15f);
    }

    public void PlaySoundEffectOro()
    {

        AudioSource.PlayClipAtPoint(lootboxoro, Camera.main.transform.position, 0.15f);
    }
    public void PlaySoundEffectChido()
    {

        AudioSource.PlayClipAtPoint(lootboxchido, Camera.main.transform.position, 0.15f);
    }
}
