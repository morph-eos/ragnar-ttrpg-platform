export function findAbility(pathsArray, abilityName) {
  for (const path of pathsArray) {
    for (const ability of path.abilities) {
      if (ability.name === abilityName) {
        return ability;
      }
    }
  }
  return null;
}