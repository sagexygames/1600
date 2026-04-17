using Godot;

public partial class GameState : Node
{
    public static GameState Instance { get; private set; }
    public enum GameMode { Easy, Normal, Hard }
        public GameMode CurrentGameMode { get; set; } = GameMode.Normal;

        // energy
        public int CurrentEnergy { get; set; } = 100;
        public int MaxEnergy { get; set; } = 100;
        public int EnergyAtLastSave { get; set; } = 100;
        public int EnergyTanksCollected { get; set; } = 0;

        public void CollectEnergyTank()
        {
            int amount = EnergyTanksCollected == 0 ? 150 : 250;
            EnergyTanksCollected++;
            MaxEnergy += amount;
            CurrentEnergy = MaxEnergy; // refill energy
        }

        // ammo
        public int Missiles { get; set; } = 5;
        public int MaxMissiles { get; set; } = 0;
        public int MissileTanksCollected { get; set; } = 0;

        public int HyperMissileAmmo { get; set; } = 0;
        public int MaxHyperMissileAmmo { get; set; } = 0;
        public int HyperMissileTanksCollected { get; set; } = 0;

        public void CollectMissileTank()
        {
            MissileTanksCollected++;
            MaxMissiles += 5;
            Missiles = MaxMissiles; // refill missiles
        }

        public void CollectHyperMissileTank()
        {
            HyperMissileTanksCollected++;
            MaxHyperMissileAmmo += 5;
            HyperMissileAmmo = MaxHyperMissileAmmo; // refill hyper missiles
        }

        // abilities
        public bool HasPulseBeam { get; set; } = true;
        public bool HasGrapplingHook { get; set; } = true;
        public bool HasMissiles { get; set; } = false;
        public bool HasFrigidBeam { get; set; } = false;
        public bool HasApexJump { get; set; } = false;
        public bool HasPhaseBeam { get; set; } = false;
        public bool HasHyperMissiles { get; set; } = false;
        public bool HasPlasmaBeam { get; set; } = false;
        public bool HasAquaModule { get; set; } = false;
        public bool NovaBeamActive { get; set; } = false;   

        // bosses
        public bool AtreusEncounter1Defeated { get; set; } = false;
        public bool ViridisDefeated { get; set; } = false;
        public bool CruentusDefeated { get; set; } = false;
        public bool FluviusDefeated { get; set; } = false;
        public bool AtreusDefeated { get; set; } = false;

        // world
        public string CurrentZone { get; set; } = "X Station";
        public string CurrentRoom { get; set; } = "xstation_landing";
        public bool EscapeTimerActive { get; set; } = false;
        public float EscapeTimeRemaining { get; set; } = 600f;

        // collectibles
        public System.Collections.Generic.HashSet<string> CollectedPickupIDs { get; set; } = new();

        public bool HasCollectedPickup(string id) => CollectedPickupIDs.Contains(id);

        public void RegisterPickup(string id)
        {
            CollectedPickupIDs.Add(id);
        }
    public override void _Ready()
    {
        Instance = this;
    }
}