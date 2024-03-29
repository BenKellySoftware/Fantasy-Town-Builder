using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ResourceCategory {
	Supply,
	Produce,
	Livestock,
	Herbs,
	Grain,
	Alcohol,
	Fibre,
	Hide,
	Fabric,
	Mineral,
	Metal,
	Gemstone,
	Stone,
	Wood,
	Hemp,
	Flax,
	Web,
	Feathers
}

[CreateAssetMenu(menuName = "ResourceType", order = 1)]
public class ResourceType: ScriptableObject {
	public ResourceCategory category;
	public int baseValue;
	public float inputMultiplier;

	/*public bool dontPluralise;
	public string singular {
		get {
			if (dontPluralise) {
				return name;
			} else if (name.EndsWith("s")) {
				return name.Remove(name.Length - 1, 1);
			} else if (name.EndsWith("y")) {
				return name.Replace("y", "ies");
			} else {
				return name;
			}
		}
	}*/
}

[System.Serializable]
public class Resource {
	public string name;
	public ResourceType type;
	public int value;
	public int count;
	public bool outgoing;

	public Resource (string name, ResourceType type, int value, int count, bool outgoing) {
		this.name = name;
		this.type = type;
		this.value = value;
		this.count = count;
	}
}

[System.Serializable]
public class Inventory {
	public int capacity;
	public List<Resource> resources;

	public Inventory(int capacity) {
		this.capacity = capacity;
		resources = new List<Resource>();
	}

	public int size {
		get { 
			int size = 0;
			foreach (Resource resource in resources) {
				size += resource.count;
			}
			return size;
		}
	}

	//Returns true if added, false if inventory full, but will still put in as many as it can
	public bool Add(Resource resource, Inventory inventory = null) {
		if (size == capacity) return false;

		int remaining = capacity - size;

		if (remaining < resource.count) { //Fill rest of the space
			Resource stack = resources.Find(x => x.name == resource.name && x.value == resource.value);
			if (stack != null) {
				stack.count += remaining;
			} else {
				resources.Add(new Resource(resource.name, resource.type, resource.value, remaining, false));
			}
			resource.count -= remaining;
			return false;
		} else { //Swap parent
			resources.Add(resource);
			if (inventory != null) inventory.resources.Remove(resource); //Only when transfering
			resource.outgoing = false;
			return true;
		}
	}

	public List<Resource> FindByCategory(ResourceCategory category) {
		return resources.FindAll(x => x.type.category == category).OrderBy(x => x.value).ToList();
	}
}