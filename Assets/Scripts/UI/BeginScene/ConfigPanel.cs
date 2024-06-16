using UnityEngine.UI;

public class ConfigPanel : BasePanel
{
    public Button btnClose;
    public Toggle togMusic;
    public Toggle togSound;
    public Slider sliderMusic;
    public Slider sliderSound;

    public override void Init()
    {
        MusicData data = GameDataMgr.Instance.musicData;
        togMusic.isOn = data.musicOpen;
        togSound.isOn = data.soundOpen;
        sliderMusic.value = data.musicValue;
        sliderSound.value = data.soundValue;

        btnClose.onClick.AddListener(() =>
        {
            GameDataMgr.Instance.SaveMusicData();
            UIManager.Instance.HidePanel<ConfigPanel>();
        });

        togMusic.onValueChanged.AddListener((v) =>
        {
            BKMusic.Instacne.SetIsOpen(v);
            GameDataMgr.Instance.musicData.musicOpen = v;
        });

        togSound.onValueChanged.AddListener((v) =>
        {
            GameDataMgr.Instance.musicData.soundOpen = v;
        });

        sliderMusic.onValueChanged.AddListener((v) =>
        {
            BKMusic.Instacne.ChangeValue(v);
            GameDataMgr.Instance.musicData.musicValue = v;
        });

        sliderSound.onValueChanged.AddListener((v) =>
        {
            //记录音效大小的数据
            GameDataMgr.Instance.musicData.soundValue = v;
        });
    }
}
