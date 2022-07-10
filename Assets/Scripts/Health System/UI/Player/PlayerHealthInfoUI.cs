using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class PlayerHealthInfoUI : MonoBehaviour
    {
        [SerializeField]
        private Image _headImage;

        [SerializeField]
        private Image _chestImage;

        [SerializeField]
        private Image _bellyImage;

        [SerializeField]
        private Image _rightTopHandImage;

        [SerializeField]
        private Image _rightBottomHandImage;

        [SerializeField]
        private Image _leftTopHandImage;

        [SerializeField]
        private Image _leftBottomHandImage;

        [SerializeField]
        private Image _rightTopLegImage;

        [SerializeField]
        private Image _rightBottomLegImage;

        [SerializeField]
        private Image _leftTopLegImage;

        [SerializeField]
        private Image _leftBottomLegImage;

        private HealthPart _head;
        private HealthPart _chest;
        private HealthPart _belly;
        private HealthPart _rightTopHand;
        private HealthPart _rightBottomHand;
        private HealthPart _leftTopHand;
        private HealthPart _leftBottomHand;
        private HealthPart _rightTopLeg;
        private HealthPart _rightBottomLeg;
        private HealthPart _leftTopLeg;
        private HealthPart _leftBottomLeg;

        private void Awake()
        {
            EventBus.Instance.AddListener<PlayerHealthRefreshEvent>(OnPlayerHealthRefresh);
            EventBus.Instance.AddListener<PlayerHealthChangedEvent>(OnPlayerHealthChanged);

            _headImage.color = Color.white;
            _chestImage.color = Color.white;
            _bellyImage.color = Color.white;
            _rightTopHandImage.color = Color.white;
            _rightBottomHandImage.color = Color.white;
            _leftTopHandImage.color = Color.white;
            _leftBottomHandImage.color = Color.white;
            _rightTopLegImage.color = Color.white;
            _rightBottomLegImage.color = Color.white;
            _leftTopLegImage.color = Color.white;
            _leftBottomLegImage.color = Color.white;
        }

        private void OnPlayerHealthRefresh(PlayerHealthRefreshEvent e)
        {
            if (_head == null)
            {
                _head = e.Head;
                _chest = e.Chest;
                _belly = e.Belly;
                _rightTopHand = e.RightTopHand;
                _rightBottomHand = e.RightBottomHand;
                _leftTopHand = e.LeftTopHand;
                _leftBottomHand = e.LeftBottomHand;
                _rightTopLeg = e.RightTopLeg;
                _rightBottomLeg = e.RightBottomLeg;
                _leftTopLeg = e.LeftTopLeg;
                _leftBottomLeg = e.LeftBottomLeg;
            }
            else
            {
                return;
                (HealthPart healthPart, Image image) = FindChangedPartAndImage(null);
                float health = healthPart.Health / healthPart.HealthPartData.Health;

                image.color = Color.Lerp(Color.white, Color.red, 10f * health);

                
            }
        }

        private void OnPlayerHealthChanged(PlayerHealthChangedEvent e)
        {
            (HealthPart healthPart, Image image) = FindChangedPartAndImage(e.ChangedPart);
            float health = healthPart.Health / healthPart.HealthPartData.Health;

            image.color = Color.Lerp(Color.white, Color.red, 10f * health);
        }

        private (HealthPart, Image) FindChangedPartAndImage(HealthPart changedPart)
        {
            if (changedPart == _head)
                return (_head, _headImage);
            else if (changedPart == _chest)
                return (_chest, _chestImage);
            else if (changedPart == _belly)
                return (_belly, _bellyImage);
            else if (changedPart == _rightTopHand)
                return (_rightTopHand, _rightTopHandImage);
            else if (changedPart == _rightBottomHand)
                return (_rightBottomHand, _rightBottomHandImage);
            else if (changedPart == _leftTopHand)
                return (_leftTopHand, _leftTopHandImage);
            else if (changedPart == _leftBottomHand)
                return (_leftBottomHand, _leftBottomHandImage);
            else if (changedPart == _rightTopLeg)
                return (_rightTopLeg, _rightTopLegImage);
            else if (changedPart == _rightBottomLeg)
                return (_rightBottomLeg, _rightBottomLegImage);
            else if (changedPart == _leftTopLeg)
                return (_leftTopLeg, _leftTopLegImage);
            else if (changedPart == _leftBottomLeg)
                return (_leftBottomLeg, _leftBottomLegImage);
            else
                throw new System.Exception("Changed health part was not found.");
        }
    }
}
