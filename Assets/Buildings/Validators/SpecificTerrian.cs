using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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