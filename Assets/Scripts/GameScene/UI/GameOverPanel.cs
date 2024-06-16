using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : BasePanel
{
    public TMP_Text resultText;
    public TMP_Text reward;

    public Button ensureBtn;

    public override void Init()
    {
        ensureBtn.onClick.AddListener(()=> {
            //隐藏面板
            UIManager.Instance.HidePanel<GameOverPanel>();
            UIManager.Instance.HidePanel<GamePanel>();
            //清空当前关卡的数据
            GameLevelMgr.Instance.ClearInfo();
            //切换场景
            SceneManager.LoadScene("BeginScene");
        });
    }

    public void InitInfo(int money, bool isWin)
    {
        resultText.text = isWin ? "Win" : "Failure";
        reward.text = money.ToString();

        //根据奖励 改变玩家数据
        GameDataMgr.Instance.playerData.haveMoney += money;
        GameDataMgr.Instance.SavePlayerData();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        Cursor.lockState = CursorLockMode.None;
    }
}
