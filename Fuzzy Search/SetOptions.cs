using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOptions : MonoBehaviour
{
    public Dropdown DropDownItem;
    public InputField LocationInputField;
    public GameObject CheckMark;
    public List<string> OptionNames = new List<string>();
    int OptionCount = 0;

    void Start ()
    {
        CheckMark.SetActive(false);

        UpdateReset(this.GetComponent<SearchIndexFunction>().LocationNamesList);
    }
	
    void Update ()
    {
        // CurrentOption = GameObject.Find("Item " + DropDownItem.value + ": " + OptionNames[DropDownItem.value]);   
	}

    public void UpdateReset(List<string> LocationNameList)
    {
        OptionNames = LocationNameList;
        OptionCount = OptionNames.Count;
        UpdateDropDownItem(OptionNames);
    }

    public void UpdateDropDownItem(List<string> Options)
    {
        DropDownItem.options.Clear();
        DropDownItem.AddOptions(Options);
    }

    public void CurrentOptionChange()
    {
        for (int n = 0; n < OptionCount; n++)
        {
            if (DropDownItem.value == n)
            {
                LocationInputField.text = OptionNames[n];
                CheckMark.SetActive(true);
            }
        }
    }

    public void CurrentSearchChange()
    {
        if(LocationInputField.text != "")
        {
            this.GetComponent<SearchIndexFunction>().Temp = LocationInputField.text;
            this.GetComponent<SearchIndexFunction>().GetIndex(this.GetComponent<SearchIndexFunction>().LocationNamesList, this.GetComponent<SearchIndexFunction>().Temp);

            UpdateReset(this.GetComponent<SearchIndexFunction>().NewLocationNamesList);
        }
        else
        {
            UpdateReset(this.GetComponent<SearchIndexFunction>().LocationNamesList);
        }
        DropDownItem.value = 0;
    }
}
