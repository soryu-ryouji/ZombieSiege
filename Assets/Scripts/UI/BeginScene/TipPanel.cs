using TMPro;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    public TMP_Text txtInfo;

    public Button btnSure;

    public override void Init()
    {
        btnSure.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<TipPanel>();
        });
    }

    /// <summary>
    /// 改变提示内容的方法
    /// </summary>
    /// <param name="str"></param>
    public void ChangeInfo(string str)
    {
        txtInfo.text = str;
    }
}
