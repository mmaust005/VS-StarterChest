using System.Collections.Generic;

namespace StarterChest
{
	public class LootEntry
	{
		/// <summary>
		/// Item or block code, e.g. "game:bread-rye-perfect", "flint" (defaults to the "game" domain
		/// if no domain is given), or "othermodid:someitem" for items/blocks added by other mods.
		/// </summary>
		public string Code = "game:flint";

		/// <summary>"item" or "block".</summary>
		public string Type = "item";

		public int MinQuantity = 1;
		public int MaxQuantity = 1;

		/// <summary>Relative chance of being picked when RandomMode is on. Ignored for FixedItems.</summary>
		public int Weight = 100;
	}

	public class StarterChestConfig
	{
		/// <summary>
		/// When true (the default, like Minecraft's random starter kit datapacks), RandomPickCount
		/// entries are randomly drawn from RandomPool and added on top of FixedItems.
		/// When false, only FixedItems are given.
		/// </summary>
		public bool RandomMode = true;

		/// <summary>How many entries to draw from RandomPool when RandomMode is true.</summary>
		public int RandomPickCount = 4;

		/// <summary>If true, the same pool entry can be picked more than once.</summary>
		public bool AllowDuplicatePicks = false;

		/// <summary>Items always placed in the chest, regardless of RandomMode.</summary>
		public List<LootEntry> FixedItems = new List<LootEntry>();

		/// <summary>Candidate items for random picks. Only used when RandomMode is true.</summary>
		public List<LootEntry> RandomPool = new List<LootEntry>
		{
			new LootEntry { Code = "game:firestarter", Type = "item", MinQuantity = 1, MaxQuantity = 1, Weight = 15 },
			new LootEntry { Code = "game:flint", Type = "item", MinQuantity = 2, MaxQuantity = 4, Weight = 25 },
			new LootEntry { Code = "game:stick", Type = "item", MinQuantity = 3, MaxQuantity = 6, Weight = 25 },
			new LootEntry { Code = "game:rope", Type = "item", MinQuantity = 1, MaxQuantity = 2, Weight = 15 },
			new LootEntry { Code = "game:bread-rye-perfect", Type = "item", MinQuantity = 1, MaxQuantity = 2, Weight = 20 },
			new LootEntry { Code = "game:cheese-cheddar-1slice", Type = "item", MinQuantity = 1, MaxQuantity = 3, Weight = 20 },
			new LootEntry { Code = "game:knife-generic-flint", Type = "item", MinQuantity = 1, MaxQuantity = 1, Weight = 10 },
		};
	}
}
