namespace Project
{
    public readonly struct PlayerHealthRefreshEvent
    {
        public readonly HealthPart Head;
        public readonly HealthPart Chest;
        public readonly HealthPart Belly;
        public readonly HealthPart RightTopHand;
        public readonly HealthPart RightBottomHand;
        public readonly HealthPart LeftTopHand;
        public readonly HealthPart LeftBottomHand;
        public readonly HealthPart RightTopLeg;
        public readonly HealthPart RightBottomLeg;
        public readonly HealthPart LeftTopLeg;
        public readonly HealthPart LeftBottomLeg;

        public PlayerHealthRefreshEvent(HealthPart head, HealthPart chest, HealthPart belly, HealthPart rightTopHand, HealthPart rightBottomHand,
            HealthPart leftTopHand, HealthPart leftBottomHand, HealthPart rightTopLeg, HealthPart rightBottomLeg, HealthPart leftTopLeg, HealthPart leftBottomLeg)
        {
            Head = head;
            Chest = chest;
            Belly = belly;
            RightTopHand = rightTopHand;
            RightBottomHand = rightBottomHand;
            LeftTopHand = leftTopHand;
            LeftBottomHand = leftBottomHand;
            RightTopLeg = rightTopLeg;
            RightBottomLeg = rightBottomLeg;
            LeftTopLeg = leftTopLeg;
            LeftBottomLeg = leftBottomLeg;
        }
    }
}
