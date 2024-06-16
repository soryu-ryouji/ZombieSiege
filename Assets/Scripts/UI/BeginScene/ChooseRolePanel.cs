using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRolePanel : BasePanel
{
    public Button btnRight;
    public Button btnLeft;
    public Button btnBack;
    public Button btnStart;
    public Button btnUnlock;
    public Text txMoney;
    public Text txAttribute;

    public Animator cameraAnimator;

    public GameObject role;

    public override void Init()
    {
    }

    private void CreateRole()
    {
        // // 启用开始按钮
        // btnStart.gameObject.SetActive(true);

        // if (role)
        // {
        //     // 每次创建新对象删除旧对象
        //     Destroy(role.gameObject);
        //     btnUnlock.gameObject.SetActive(false);
        // }

        // role = Instantiate(Resources.Load<GameObject>(DataManager.Instance.roleInfos[DataManager.Instance.nowRoleID].path),
        //     Main.Instance.showRolePos);

        // // 失活角色脚本防止交互
        // role.GetComponent<Player>().enabled = false;

        // if (!DataManager.Instance.playerInfo.unlockRoles.Contains(DataManager.Instance.nowRoleID))
        // {
        //     // 未解锁显示解锁按钮
        //     btnUnlock.gameObject.SetActive(true);
        //     btnUnlock.transform.Find("TxNum").GetComponent<Text>().text =
        //         DataManager.Instance.roleInfos[DataManager.Instance.nowRoleID].unlockMoney + "金币";
        //     // 禁用开始按钮
        //     btnStart.gameObject.SetActive(false);
        // }

        // // 更新角色属性
        // UpdateRoleAttribute(DataManager.Instance.roleInfos[DataManager.Instance.nowRoleID].baseAtk,
        //     DataManager.Instance.roleInfos[DataManager.Instance.nowRoleID].mainBullets);
    }

    public void UpdateRoleAttribute(int baseAtk, int bullets)
    {
        txAttribute.text = $"基础攻击力+{baseAtk}\n携带子弹:{bullets}";
    }
}