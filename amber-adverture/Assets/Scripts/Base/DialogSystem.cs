using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance;
    public TextAsset storyAsset; // 剧本
    public KeyCode nextKey = KeyCode.Space; // 下一句按键

    // 角色信息，名字、图片、表情
    [Tooltip("角色名")]
    public string[] roleName;
    [Tooltip("对话主角立绘")]
    public Image MajorImage;
    [Tooltip("Npc立绘")]
    public Image NpcImage;
    [Tooltip("主角表情包")]
    public Sprite[] MajorFace;
    [Tooltip("Npc1表情包")]
    public Sprite[] Npc1Face;
    private List<Sprite[]> allNpcFace = new List<Sprite[]>(); // 将Npc的表情组扔在一起管理

    // 对话面板
    public Text displayName;
    public Text content;

    public GameObject mainUi; // 对话时隐藏主UI

    private Animation anim;
    private bool isDialog = false; // 是否在对话中
    private string[] stories; // 将 storyAsset 存储到对话数组中
    private int storiesIndex = 0; // 对话数组当前索引
    private string line; // 读取到的一行数据
    private bool isPrintting = false; // 是否在打印中

    void Awake()
    {
        instance = this;
        anim = GetComponent<Animation>();

        allNpcFace.Add(Npc1Face);
    }

    void Update()
    {
        if (!isDialog)
            return;

        // Go Next
        if (Input.GetKeyDown(nextKey))
        {
            Next();
        }

    }

    public void Begin()
    {
        GameplayManager.instance.pause = true;
        mainUi.SetActive(false);
        PlayAnim();
        isDialog = true;

        // 储存剧本
        stories = storyAsset.text.Split('\n');

        // 避免 End 之后重新开始对话 storiesIndex 为最后一行
        storiesIndex = 0;
        // 读取第一行
        Next();

    }

    public IEnumerator End()
    {
        // 立即停止响应按键事件
        isDialog = false;
        HideAnim();

        // 等待1秒后执行下面的代码
        yield return new WaitForSeconds(1f);
        mainUi.SetActive(true);
        GameplayManager.instance.pause = false;


    }

    // 读取并解析对话剧本，每次一行
    // @0>3 是表情行，以 @ 开头; 0>3：0 代表主角，其他代表 npc; 3 代表表情数组的索引
    public void Next()
    {
        // 在打印期间再次按下空格,则直接打印整句(正在打印中的这句)
        if (isPrintting)
        {
            content.text = line;
            isPrintting = false;
            return;
        }

        // 读完所有行
        if (storiesIndex >= stories.Length - 1)
        {
            StartCoroutine(End());
            return;
        }

        line = stories[storiesIndex];

        // 如果读到的是表情行，则更换表情，然后继续读下一行
        if (line.StartsWith("@"))
        {
            ChangeFace(int.Parse(line[1].ToString()), int.Parse(line[3].ToString()));
            storiesIndex++;
            Next();
        }
        // 如果读到内容行，则更换角色名与打印内容
        else
        {
            ChangeName(int.Parse(line[0].ToString()));
            StartCoroutine(PrintContent());
            storiesIndex++;
        }
    }

    // 更换表情
    void ChangeFace(int role, int faceId)
    {
        if (role == 0)
            MajorImage.sprite = MajorFace[faceId];
        else
            NpcImage.sprite = allNpcFace[role - 1][faceId];
    }

    // 更换对话角色名
    void ChangeName(int role)
    {
        displayName.text = roleName[role];
    }

    // 打印对话内容
    IEnumerator PrintContent()
    {
        int charIndex = 0;
        line = line.Substring(2); // 去掉 1:
        content.text = "";
        isPrintting = true;

        while (isPrintting)
        {
            content.text += line[charIndex];
            charIndex++;

            if (charIndex >= line.Length)
            {
                isPrintting = false;
                break;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    public void PlayAnim()
    {
        // 正播动画
        anim["DialogAnimation"].normalizedTime = 0;
        anim["DialogAnimation"].speed = 1;
        anim.Play();
    }

    public void HideAnim()
    {
        // 倒播动画
        anim["DialogAnimation"].normalizedTime = 1;
        anim["DialogAnimation"].speed = -1;
        anim.Play();
    }
}
