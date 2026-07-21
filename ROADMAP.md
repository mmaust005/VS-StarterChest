# Roadmap

Nothing currently planned - suggestions welcome. Character-class-specific loadouts live in a
separate addon (**Starter Chest: Class Loadouts**) built on this mod's public addon API, not in
this repo - see the README's "Addons" section.

## Done (since v1.0.0)

- ~~Dry-run command~~ - `/starterchest preview <player>` rolls and prints what would be given,
  without spawning a chest.
- ~~Auto-fit picks to slots~~ - `RandomPickCount` now automatically caps itself to the real
  container's remaining slots (read from the placed container, so it works for modded containers
  too), instead of warning and dropping overflow.
- ~~Localization~~ - the starter-chest chat message now resolves per-player via
  `assets/starterchest/lang/en.json` instead of being hardcoded English.
- ~~Public addon API~~ - `RegisterLoadoutProvider` lets other mods (like the class-loadouts
  addon) override the loadout for specific players without forking this mod.
