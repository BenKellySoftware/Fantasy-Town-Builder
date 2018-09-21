//http://ericeastwood.com/blog/20/texture-tiling-based-on-object-sizescale-in-unity
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Overlay : MonoBehaviour {

	[Range(0.2f, 10f)]
	public float tilesPerScale = 1;

	private float prevTilesPerScale;
	private Vector3 prevScale;


	// Use this for initialization
	void Start () {
		UpdateTiling();
	}

	// Update is called once per frame
	void Update () {
		// If something has changed
		if (gameObject.transform.lossyScale != prevScale || tilesPerScale != prevTilesPerScale) {
			UpdateTiling();
		}
	}

	//x offset modifiers found through experimentation
	private const float xOffsetScaling = -0.288675f;
	private const float xOffsetBase = -0.5f;

	void UpdateTiling() {
		prevScale = transform.lossyScale;
		prevTilesPerScale = tilesPerScale;

		float xTiling = tilesPerScale * transform.lossyScale.x / Mathf.Sqrt(3);
		float yTiling = tilesPerScale * transform.lossyScale.z;
		GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2(xTiling, yTiling);

		float xOffset = tilesPerScale * (xOffsetScaling * transform.lossyScale.x) + xOffsetBase;
		float yOffset = (1 - (tilesPerScale * transform.lossyScale.z)) / 2;
		GetComponent<Renderer>().sharedMaterial.mainTextureOffset = new Vector2(xOffset, yOffset);
	}
}
