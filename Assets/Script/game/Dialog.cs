using UnityEngine;

public class Dialog
{
    private string[] dialogs;
    private string portrait;
    private int currentDialog;

    public Dialog(string dialog)
    {
        this.setDialog(new string[] { dialog });
    }

    public Dialog(string[] dialogs, string portrait = null)
    {
        this.portrait = portrait;
        this.setDialog(dialogs);
    }

    public void setDialog(string[] dialogs)
    {
        this.dialogs = dialogs;
        this.currentDialog = 0;
    }

    public string getPortrait()
    {
        return this.portrait;
    }

    public string[] getText()
    {
        return this.dialogs;
    }

    public bool hasPortrait()
    {
        return this.portrait != null;
    }

    public bool hasDialogs()
    {
        return this.dialogs.Length > 0;
    }

    public string getCurrentDialog()
    {
        return this.dialogs[currentDialog];
    }

    public bool hasNextDialog()
    {
        return this.currentDialog < this.dialogs.Length - 1;
    }

    public string goToNextDialog()
    {
        this.currentDialog = this.currentDialog + 1;
        return this.dialogs[this.currentDialog];
    }
}