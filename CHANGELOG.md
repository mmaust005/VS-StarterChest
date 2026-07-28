# Changelog

## 1.2.0

### Added
- A second public addon API, `StarterChestModSystem.RegisterLoadoutModifier`, lets an addon
  append to or adjust the loadout a provider (or the top-level config) already resolved, instead
  of replacing it outright - e.g. adding cold-weather gear on top of whatever a class-based
  provider picked. Multiple modifiers can be registered and all run, in registration order. See
  the README's "Addons" section.
- `ContainerCode` accepts a new special value, `"auto"` (now the packaged default), which picks
  the smallest of the reed basket/chest/trunk that can fit however many `FixedItems` actually end
  up guaranteed for a given player - including whatever addons like Class Loadouts or World
  Conditions contribute - instead of always using one fixed container regardless of how many
  addons are installed. Set `ContainerCode` to a specific code to opt out and pin a container,
  same as before "auto" existed.

### Changed
- `RegisterLoadoutProvider`'s optional `readyCheck` now polls until it actually passes instead of
  giving up after a fixed timeout, so an addon-provided loadout (e.g. by character class) can
  never be resolved from stale/default state. A `readyCheck`, loadout provider, or loadout
  modifier that throws is now logged and safely contained instead of breaking chest placement for
  that player - a `readyCheck` failure is treated as not-ready (and retried), a provider failure
  falls back to the top-level config, and a modifier failure just skips that modifier.

## 1.1.0

### Added
- `/starterchest preview <player>` command - rolls the configured loot and prints what would be
  given, without spawning a chest or touching the player's received-chest flag.
- The starter-chest chat message is now localized per-player
  (`assets/starterchest/lang/en.json`) instead of being hardcoded English, and now names the
  actual configured container (chest, trunk, or whatever a modded one calls itself) instead of
  assuming "chest".
- A public addon API (`StarterChestModSystem.RegisterLoadoutProvider`) lets other mods override
  what a specific player gets - e.g. varying the loadout by character class - without forking or
  duplicating this mod's placement/container logic. See the README's "Addons" section.
- `examples/` has 3 complete, ready-to-use configs (low/medium/high tier - reed chest with
  stone-age basics, chest with copper tools, trunk with tin-bronze tools) to copy from. Not
  loaded by the mod.

### Changed
- `RandomPickCount` now automatically caps itself to the real container's remaining slots (read
  from the placed container, so this works correctly for modded containers too) instead of
  rolling the full count and dropping/warning about overflow afterwards.
- Default `ContainerCode` is now `game:stationarybasket` (a small reed chest, 8 slots) instead of
  the 16-slot chest - a starter kit fits comfortably without a backpack. Default `RandomPickCount`
  bumped from 4 to 5 to match.

## 1.0.0

Initial release.

- One-time starter chest per player: guaranteed `FixedItems`, a weighted `RandomPool`, or both.
- Configurable container block and facing direction - the default chest, the trunk, or any other
  placeable container block, including modded ones.
- `/starterchest reset <player>` command for testing config changes without restarting the server.
