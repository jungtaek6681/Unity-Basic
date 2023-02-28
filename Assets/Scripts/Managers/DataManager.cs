using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
	[SerializeField]
	private int shootCount;

	public UnityAction<int> OnShootChanged;

	public void AddShootCount(int count)
	{
		shootCount += count;
		OnShootChanged?.Invoke(shootCount);
	}
}
