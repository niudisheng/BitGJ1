using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class DialogManager : MonoBehaviour
{
    public Image Image;
    public GameObject descption;
    public TMP_Text description;
    public TMP_Text itemName;
    [Header("组件")]
    public GameObject dialogue;
    //对话框
    public TMP_Text nPCName;
    //角色名
    public TMP_Text dialog;
    //对话内容
    public SpriteRenderer sprite;
    //角色图片
    public Button nextButton;
    //下一句对话
    public bool isPause;
    //是否对话是暂停

    public string oneName;
    public string twoName;
    public TextAsset TextAsset;
    //对话内容
    public List<Sprite> sprites = new List<Sprite>();
    //角色图片
    Dictionary<string,Sprite> imageDir = new Dictionary<string,Sprite>();
    //角色图片与名字对应
    public int dialogIndex;
    //对话索引
    public int maxdialogIndex;
    //最大索引
    public string[] dialogRows;
    //对话全部内容
    private string[] cell;
    //单次对话内容
    public UnityAction UnityAction;
    public bool isOver;
    private void Awake()
    {
        //重置
        //imageDir.Clear();
        dialogue.SetActive(false);
        dialogIndex = 1;
        maxdialogIndex = 1;
    }
    private void UpdateDialog(string name,string dialogs)
    {
        //更新文字
        nPCName.text = name;
        dialog.text = dialogs;
    }
    private void UpdateImage(string name)
    {
        //角色图片
        sprite.sprite = imageDir[name];
    }
    public void ReadText(TextAsset text)
    {
        //分割文字
        dialogRows = text.text.Split(('\n'));
    }

    //从文档中获取文字
    public void ShowDialogRow()
    {
        foreach (var row in dialogRows)
        {
            imageDir[oneName] = sprites[0];
            imageDir[twoName] = sprites[1];
            //再次分割
            string[] cells = row.Split(',');
            if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
            {
                if (dialogIndex == 2)
                {
                    cell = cells;
                }
                UpdateImage(cells[2]);
                UpdateDialog(cells[2], cells[3]);
                dialogIndex = int.Parse(cells[4]);
                break;
            }
            else if (cells[0] == "@" && int.Parse(cells[1]) == dialogIndex)
            {
                UpdateImage(cells[2]);
                UpdateDialog(cells[2], cells[3]);
                dialogIndex = int.Parse(cells[4]);
                break;
            }
            if (cells[0] == "end")
            {
                //UpdateImage(cell[2]);
                //UpdateDialog(cell[2], cell[3]);
                dialogue.gameObject.SetActive(false);
                dialogIndex = 1;
                Time.timeScale = 1;
                isOver = true;
                UnityAction?.Invoke();
            }
        }
    }

    //点击按钮的事件
    public void OnClickNext()
    {
        {
            Time.timeScale = 0;
            ShowDialogRow();
        }
    }
}
