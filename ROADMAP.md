# Roadmap

- **Class-based starter loadouts** - not generic themed "kits" (fisher vs miner) - the starter
  chest should reflect the character class the player picked at creation, so a Hunter and a
  Clockmaker get different, class-appropriate loadouts instead of the same random pool.

  Design: a new optional `ClassLoadouts` config map, keyed by class code, where each entry has
  its own `FixedItems`/`RandomPool`/`RandomPickCount`/`AllowDuplicatePicks` (same shape as the
  existing top-level config). The player's chosen class is read server-side from their entity at
  give-time. Classes with no matching entry (including modded classes) fall back to the existing
  top-level `FixedItems`/`RandomPool` config, so this is purely additive - existing configs keep
  working unchanged.

## Done (since v1.0.0)

- ~~Dry-run command~~ - `/starterchest preview <player>` rolls and prints what would be given,
  without spawning a chest.
- ~~Auto-fit picks to slots~~ - `RandomPickCount` now automatically caps itself to the real
  container's remaining slots (read from the placed container, so it works for modded containers
  too), instead of warning and dropping overflow.
- ~~Localization~~ - the starter-chest chat message now resolves per-player via
  `assets/starterchest/lang/en.json` instead of being hardcoded English.
