using System.Collections.Generic;
using Vintagestory.API.Server;

namespace StarterChest
{
	// Loot settings for one starter chest - same shape and meaning as the top-level
	// StarterChestConfig fields of the same name. Returned by a StarterChestLoadoutProvider to
	// override the top-level config for a given player.
	public class StarterChestLoadout
	{
		public bool RandomMode = true;
		public int RandomPickCount = 5;
		public bool AllowDuplicatePicks = false;
		public List<LootEntry> FixedItems = new List<LootEntry>();
		public List<LootEntry> RandomPool = new List<LootEntry>();

		// Deep copy - used before running registered modifiers, so a modifier can never mutate a
		// shared config/provider-owned object that other players (or the next resolve for the same
		// player) would read afterwards.
		public StarterChestLoadout Clone()
		{
			return new StarterChestLoadout
			{
				RandomMode = RandomMode,
				RandomPickCount = RandomPickCount,
				AllowDuplicatePicks = AllowDuplicatePicks,
				FixedItems = FixedItems.ConvertAll(e => e.Clone()),
				RandomPool = RandomPool.ConvertAll(e => e.Clone()),
			};
		}
	}

	// Returned by a registered loadout provider. See StarterChestModSystem.RegisterLoadoutProvider.
	public class StarterChestLoadoutResult
	{
		// Loot settings to use instead of the top-level config. Required.
		public StarterChestLoadout Loadout;

		// Optional, already-localized label shown in the "A starter {DisplayName} chest has
		// appeared nearby!" message and in /starterchest preview output (e.g. "Hunter"). Leave
		// null/empty to use the generic, unlabeled message instead.
		public string DisplayName;
	}

	// Called once StarterChestModSystem is ready to resolve a loadout for a player. Return null to
	// fall back to the top-level config. See RegisterLoadoutProvider.
	public delegate StarterChestLoadoutResult StarterChestLoadoutProvider(IServerPlayer player);

	// Called while StarterChestModSystem decides whether it is safe to give a new player their
	// automatic chest yet. Return false to wait and check again shortly. See RegisterLoadoutProvider.
	public delegate bool StarterChestReadyCheck(IServerPlayer player);

	// Called after the loadout provider (or the top-level config, if none) has resolved a
	// loadout, to append or adjust it rather than replace it outright - e.g. adding cold-weather
	// gear on top of whatever a class/origin/theme provider already picked. Every registered
	// modifier runs, in registration order, each receiving the previous one's result. loadout is
	// always a private copy the modifier is free to mutate directly and return, or to leave
	// untouched and return unchanged. See StarterChestModSystem.RegisterLoadoutModifier.
	public delegate StarterChestLoadout StarterChestLoadoutModifier(IServerPlayer player, StarterChestLoadout loadout);
}
