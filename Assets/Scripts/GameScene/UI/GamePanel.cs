using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    public Image bloodImage;
    public TMP_Text bloodInfo;
    public TMP_Text remainingCount;
    public TMP_Text playerMoney;
    public Button quitBtn;

    //下方造塔组合控件的父对象 主要用于控制 显隐
    public Transform botTrans;

    //管理 3个复合控件
    public List<TowerBtn> towerBtns = new List<TowerBtn>();

    //当前进入和选中的造塔点
    private TowerPoint nowSelTowerPoint;

    //用来标识  是否检测 造塔输入的
    private bool checkInput;

    public override void Init()
    {
        quitBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<GamePanel>();
            SceneManager.LoadScene("BeginScene");
        });

        //一开始隐藏下方和造塔相关的UI
        botTrans.gameObject.SetActive(false);
        //锁定鼠标
        Cursor.lockState = CursorLockMode.Confined;
    }

    /// <summary>
    /// 更新安全区域血量函数
    /// </summary>
    /// <param name="hp">当前血量</param>
    /// <param name="maxHP">最大血量</param>
    public void UpdateTowerHp(int hp, int maxHP)
    {
        bloodInfo.text = hp + "/" + maxHP;
        (bloodImage.transform as RectTransform).sizeDelta = new Vector2((float) hp / maxHP * 750, 40);
    }

    /// <summary>
    /// 更新剩余波数
    /// </summary>
    /// <param name="nowNum">当前波数</param>
    /// <param name="maxNum">最大波数</param>
    public void UpdateWaveNum(int nowNum, int maxNum)
    {
        playerMoney.text = nowNum + "/" + maxNum;
    }

    /// <summary>
    /// 更新金币数量
    /// </summary>
    /// <param name="money">当前获得的金币</param>
    public void UpdateMoney(int money)
    {
        playerMoney.text = money.ToString();
    }


    /// <summary>
    /// 更新当前选中造塔点 界面的一些变化
    /// </summary>
    public void UpdateSelTower(TowerPoint point)
    {
        //根据造塔点的信息 决定 界面上的显示内容
        nowSelTowerPoint = point;

        //如果传入数据是空
        if (nowSelTowerPoint == null)
        {
            checkInput = false;
            //隐藏下方造塔按钮
            botTrans.gameObject.SetActive(false);
        }
        else
        {
            checkInput = true;
            //显示下方造塔按钮
            botTrans.gameObject.SetActive(true);

            //如果没有造过塔
            if (nowSelTowerPoint.nowTowerInfo == null)
            {
                for (int i = 0; i < towerBtns.Count; i++)
                {
                    towerBtns[i].gameObject.SetActive(true);
                    towerBtns[i].InitInfo(nowSelTowerPoint.chooseIDs[i], "数字键" + (i + 1));
                }
            }
            //如果造过塔
            else
            {
                for (int i = 0; i < towerBtns.Count; i++)
                {
                    towerBtns[i].gameObject.SetActive(false);
                }
                towerBtns[1].gameObject.SetActive(true);
                towerBtns[1].InitInfo(nowSelTowerPoint.nowTowerInfo.nextLev, "空格键");
            }
        }

    }

    protected override void Update()
    {
        base.Update();
        //主要用于造塔点 键盘输入 造塔
        if (!checkInput)
            return;

        //如果没有造过塔 那么久检测1 2 3 按钮去建造塔
        if (nowSelTowerPoint.nowTowerInfo == null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                nowSelTowerPoint.CreateTower(nowSelTowerPoint.chooseIDs[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                nowSelTowerPoint.CreateTower(nowSelTowerPoint.chooseIDs[1]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                nowSelTowerPoint.CreateTower(nowSelTowerPoint.chooseIDs[2]);
            }
        }
        //造过塔 就检测空格键 去建造
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                nowSelTowerPoint.CreateTower(nowSelTowerPoint.nowTowerInfo.nextLev);
            }
        }
    }
}
