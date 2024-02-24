using TMPro;
using UnityEngine;

public class TotalFireCountView : MonoBehaviour
{
    [SerializeField] TMP_Text textView;

    private void OnEnable()
    {
        UpdateText(Manager.Data.TotalFireCount);
        Manager.Data.OnTotalFireCountChanged += UpdateText;
    }

    private void OnDisable()
    {
        Manager.Data.OnTotalFireCountChanged -= UpdateText;
    }

    private void UpdateText(int count)
    {
        textView.text = count.ToString();
    }
}
