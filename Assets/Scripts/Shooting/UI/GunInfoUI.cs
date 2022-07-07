using TMPro;
using UnityEngine;

namespace Project
{
    public class GunInfoUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _currentAndMaxTurnAmmoText;

        [SerializeField]
        private TMP_Text _totalAmmoText;

        private void Awake()
        {
            EventBus.Instance.AddListener<CurrentGunUpdatedEvent>(OnCurrentGunUpdated);
        }

        private void OnCurrentGunUpdated(CurrentGunUpdatedEvent e)
        {
            _currentAndMaxTurnAmmoText.text = $"{e.CurrentAmmo}/{e.MaxTurnAmmo}";
            _totalAmmoText.text = e.TotalAmmo.ToString();
        }
    }
}
