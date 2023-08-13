export function modifier(stat) {
  const mod = Math.floor((stat - 10) / 2);
  return mod >= 0 ? `+${mod}` : mod.toString();
}

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