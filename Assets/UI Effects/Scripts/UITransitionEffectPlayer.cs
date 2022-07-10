using UnityEngine;

namespace Coffee.UIEffects
{
    public class UITransitionEffectPlayer : MonoBehaviour
    {
        [SerializeField]
        private bool _playOnStart = true;

        [SerializeField]
        private bool _toPlus = true;

        public void Play()
        {
            UITransitionEffect effect = GetComponent<UITransitionEffect>();

            if (_toPlus)
                effect.effectFactor = 0f;
            else
                effect.effectFactor = 1f;

            effect.effectPlayer.Play(false);
        }

        private void Start()
        {
            if (_playOnStart)
                Play();
        }
    }
}
