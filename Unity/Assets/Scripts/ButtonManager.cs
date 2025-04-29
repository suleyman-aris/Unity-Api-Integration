using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public UserApiManager userApiManager; 
    public TMP_InputField inputFieldName; 
    public TMP_InputField inputFieldId; 

    public void OnCreateButtonClick()
    {
        string name = inputFieldName.text;
        if (!string.IsNullOrEmpty(name))
        {
            StartCoroutine(userApiManager.CreateUser(name));
        }
    }

    public void OnGetButtonClick()
    {
        if (int.TryParse(inputFieldId.text, out int id))
        {
            StartCoroutine(userApiManager.GetUser(id));
        }
    }

    public void OnUpdateButtonClick()
    {
        if (int.TryParse(inputFieldId.text, out int id))
        {
            string newName = inputFieldName.text;
            if (!string.IsNullOrEmpty(newName))
            {
                StartCoroutine(userApiManager.UpdateUser(id, newName));
            }
        }
    }

    public void OnDeleteButtonClick()
    {
        if (int.TryParse(inputFieldId.text, out int id))
        {
            StartCoroutine(userApiManager.DeleteUser(id));
        }
    }
}
