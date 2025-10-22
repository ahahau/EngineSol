using _01.Code.Manager;

namespace _01.Code.Players.States
{
    public class PlayerBuildingState : PlayerState
    {
        public PlayerBuildingState(Entities.Entity entity, int animationHash) : base(entity, animationHash)
        {
        }

        public override void Enter()
        {
            base.Enter();
            GameManager.Instance.BuildingManager.SetBuildingModeActive(true);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}