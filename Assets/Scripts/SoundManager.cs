using UnityEngine;

namespace DefaultNamespace {
    public class SoundManager : MonoBehaviour {
        public enum Sound {
            BubbleRepair,
            ButtonHover,
            ButtonSound2,
            BuyingSound,
            FireLaser,
            LoseSound,
            WinSound,
        }

        public void Play(int childIndex) {
            transform.GetChild(childIndex).GetComponent<AudioSource>().Play();
        }
    }
}