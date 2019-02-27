using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingAction : ScriptableObject {
	public bool active;
	public int jobLength;
	public JobType job;
	//Checks if the job can be done
	public abstract bool Available(Citizen user, Building building);
	public abstract void Use(Citizen user, Building building);
}

public enum JobType {
	Builder,
	Porter,
	//Trader,
	//Production
	Raw,
	Farmer,
	Hunter,
	Forager,
	Fisher,
	Miner,
	Logger,
	//Refining
	Miller,
	Sawyer,
	Brewer,
	Tanner,
	Weaver,
	Tailor,
	Metallurgist,
	Carpenter,
	Mason,
	Blacksmith,
	Glassblower,
	Scribe,
	Herbalist,
	Alchemist,
	Artificer,
	//Services
	Merchant,
	Bartender,
	Innkeeper,
	Librarian,
	Teacher,
	Professor,
	Priest,
	Guard,
}