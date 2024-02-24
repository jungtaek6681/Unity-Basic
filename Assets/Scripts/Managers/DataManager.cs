using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    [SerializeField] int totalFireCount;
    public int TotalFireCount
    {
        set
        {
            totalFireCount = value;
            OnTotalFireCountChanged?.Invoke(value);
        }
        get
        {
            return totalFireCount;
        }
    }

    public UnityAction<int> OnTotalFireCountChanged;

    public void Init()
    {
        totalFireCount = 0;
    }
}
