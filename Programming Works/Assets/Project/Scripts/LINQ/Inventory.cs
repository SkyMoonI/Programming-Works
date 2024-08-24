using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public List<Item> items;
	// Start is called before the first frame update
	void Start()
	{
		var itemsGroupedByType = items
		.GroupBy(item => item.Type)
		.Select(group => new
		{
			Type = group.Key,
			Count = group.Count()
		});

		foreach (var group in itemsGroupedByType)
		{
			Debug.Log($"Item Type: {group.Type}, Count: {group.Count}");
		}
	}

}

public class Item
{
	public string Name;
	public string Type;
}
