using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class HexValidator : ScriptableObject {
	public List<TerrainType> validTerrain;
	public abstract bool Valid (Hex hex);
	public abstract bool Valid (List<Hex> hexes); // for multi tile structures
}
