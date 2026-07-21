using System.Collections.Generic;
using Vintagestory.API.Server;

namespace StarterChest
{
	/// <summary>
	/// The loot settings for one starter chest - same shape and meaning as the top-level
	/// StarterChestConfig fields of the same name. Returned by a StarterChestLoadoutProvider to
	/// override the top-level config for a given player.
	/// </summary>
	public class StarterChestLoadout
	{
		public bool RandomMode = true;
		public int RandomPickCount = 4;
		public bool AllowDuplicatePicks = false;
		public List<LootEntry> FixedItems = new List<LootEntry>();
		public List<LootEntry> RandomPool = new List<LootEntry>();
	}

	/// <summary>Returned by a registered loadout provider - see StarterChestModSystem.RegisterLoadoutProvider.</summary>
	public class StarterChestLoadoutResult
	{
		/// <summary>The loot settings to use instead of the top-level config. Required.</summary>
		public StarterChestLoadout Loadout;

		/// <summary>
		/// Optional, already-localized label shown in the "A starter {DisplayName} chest has
		/// appeared nearby!" message and in /starterchest preview output (e.g. "Hunter"). Leave
		/// null/empty to use the generic, unlabeled message instead.
		/// </summary>
		public string DisplayName;
	}

	/// <summary>
	/// Called once StarterChestModSystem is ready to resolve a loadout for this player. Return
	/// null to fall back to the top-level config for this player. See RegisterLoadoutProvider.
	/// </summary>
	public delegate StarterChestLoadoutResult StarterChestLoadoutProvider(IServerPlayer player);

	/// <summary>
	/// Called while StarterChestModSystem is deciding whether it's safe to give a new player their
	/// automatic chest yet. Return false to make it wait and check again shortly. See
	/// RegisterLoadoutProvider.
	/// </summary>
	public delegate bool StarterChestReadyCheck(IServerPlayer player);
}
