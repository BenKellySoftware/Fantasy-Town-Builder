using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class HexValidator : ScriptableObject {
	public List<TerrainType> validTerrain;
	public abstract bool Valid (Hex hex);
	public abstract bool Valid (List<Hex> hexes); // for multi tile structures
}

[CreateAssetMenu(menuName = "Hex Validator/Specific Terrain")]
public class SpecificTerrain : HexValidator {
	public override bool Valid (Hex hex) {
		return validTerrain.Contains(hex.terrain);
	}

	public override bool Valid (List<Hex> hexes) {
		float min = Utilities.ALTITUDE_MAX;
		float max = 0;
		foreach (Hex hex in hexes) {
			if (!validTerrain.Contains(hex.terrain)) return false;
			if (hex.altitude < min) min = hex.altitude;
			if (hex.altitude > max) max = hex.altitude;
		}
		return max - min <= Utilities.ALTITUDE_DIFF_MAX;
	}
}

[CreateAssetMenu(menuName = "Hex Validator/On And Adjacent")]
public class OnAndAdjacent : HexValidator { //Structure must be on a valid tile, and be surrounded by either itself or 
	public List<TerrainType> validAdjacent;

	public override bool Valid (Hex hex) {
		if (!validTerrain.Contains(hex.terrain)) return false;

		for (int i = 0; i < 6; i++) {
			Hex neighbour = hex.FindNeighbour(i);
			if (validAdjacent.Contains(neighbour.terrain)) return true;
		}
		return false;
	}

	public override bool Valid (List<Hex> hexes) {
		Debug.LogError("Not yet implemented");
		return false;
	}
}
