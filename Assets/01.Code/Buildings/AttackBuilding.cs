namespace _01.Code.Buildings
{
    public class AttackBuilding : Building
    {
        private BuildingAttacker _attacker;
        protected override void Awake()
        {
            base.Awake();
            _attacker = GetCompo<BuildingAttacker>();
        }
    }
}