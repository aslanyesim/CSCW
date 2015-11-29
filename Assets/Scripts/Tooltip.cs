using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Tooltip : MonoBehaviour {
	public List<Plate> plates = new List<Plate>();
	public Text info;
	private TooltipDatabase tooltipDatabase;

	void Start()
	{
		/*Grabs the component from the same Gameobject. 
		 * TooltipDatabase and Tooltip are both added to the same gameobject (tooltips)
		 * That's why this works.
		 */
		tooltipDatabase = GetComponent<TooltipDatabase>();

	}

	void Update(){
		Plate plateInfo = tooltipDatabase.FetchPlateInfoByID(0);
		info.text = "\n" + "Title: " + plateInfo.Title + "\n" + "Process: " + plateInfo.Process;
	}
}
