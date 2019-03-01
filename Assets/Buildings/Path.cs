using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Path : Building {
	public bool[] neighboursLinked = new bool[6];

	//For use with place
	private Hex hoveredHex = null;
	Hex start;
	Hex end;

	public override void Place(Hex hex) {
		// Click start and end, or drag a line	
	}
}
