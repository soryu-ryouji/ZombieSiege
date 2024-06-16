using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutPanel : BasePanel
{
    public Text txtInfo;

    public Button btnSure;

    public override void Init()
    {
        btnSure.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<AboutPanel>();
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
