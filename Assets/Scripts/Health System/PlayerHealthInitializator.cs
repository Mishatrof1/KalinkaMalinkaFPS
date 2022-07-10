using UnityEngine;

namespace Project
{
    public class PlayerHealthInitializator : MonoBehaviour
    {
        public HealthPart Head;
        public HealthPart Chest;
        public HealthPart Belly;
        public HealthPart RightTopHand;
        public HealthPart RightBottomHand;
        public HealthPart LeftTopHand;
        public HealthPart LeftBottomHand;
        public HealthPart RightTopLeg;
        public HealthPart RightBottomLeg;
        public HealthPart LeftTopLeg;
        public HealthPart LeftBottomLeg;

        private void Start()
        {
            GetComponent<HealthObject>().Refresh();

            PlayerHealthRefreshEvent refreshEvent = new PlayerHealthRefreshEvent(
                Head,
                Chest,
                Belly,
                RightTopHand,
                RightBottomHand,
                LeftTopHand,
                LeftBottomHand,
                RightTopLeg,
                RightBottomLeg,
                LeftTopLeg,
                LeftBottomLeg);

            EventBus.Instance.Send(refreshEvent);
        }
    }
}
