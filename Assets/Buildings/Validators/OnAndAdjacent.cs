using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
