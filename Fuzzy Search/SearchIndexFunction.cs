using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Linq;

public class SearchIndexFunction : MonoBehaviour
{
    /*
    public class ReverserArrayList : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(y, x));
        }
    }
    */

    string Path = "E:\\Unity3D\\Projects\\BFDEMO\\Assets\\Txts\\Locations.txt";

    public List<string> LocationNamesList = new List<string>();
    public List<string> LocationNamesListCopy = new List<string>();
    public List<string> LocationFirstLetterList = new List<string>();
    public List<string> LocationFirstLetterListCopy = new List<string>();
    public List<string> NewLocationNamesList = new List<string>();
    public List<int> SortIndexList = new List<int>();
    public List<int> IndexList = new List<int>();
    string FirstLetterCombination = "";
    int ListCount = 0;

    public string Temp = "";

    void Start()
    {
        ReadTxt(Path, LocationNamesList, LocationNamesListCopy);
        ListCount = LocationNamesList.Count;

        for (int n = 0; n < ListCount; n++)
        {
            FirstLetterCombination = GetEachChar(LocationNamesList[n]);
            LocationFirstLetterList.Add(FirstLetterCombination);
            LocationFirstLetterListCopy.Add(FirstLetterCombination);
        }

        LocationFirstLetterList.Sort();

        for (int n1 = 0; n1 < ListCount; n1++)
        {
            for (int n2 = 0; n2 < ListCount; n2++)
            {
                if (LocationFirstLetterList[n1] == LocationFirstLetterListCopy[n2])
                {
                    SortIndexList.Add(n2);
                }
            }
            LocationNamesList[n1] = LocationNamesListCopy[SortIndexList[n1]];
        }

        /*
        for (int n = 0; n < ListCount; n++)
        {
            Debug.Log(LocationNamesList[n]);
            Debug.Log(LocationNamesListCopy[n]);
            Debug.Log(LocationFirstLetterList[n]);
            Debug.Log(LocationFirstLetterListCopy[n]);
            Debug.Log(SortIndexList[n]);

        }
        for (int n = 0; n < IndexList.Count; n++)
        {
            Debug.Log(IndexList[n]);
            Debug.Log(NewLocationNamesList[n]);
        }
        */
    }
    void Update()
    {

    }

    public void ReadTxt(string Path, List<string> LocationName, List<string> LocationNameCopy)
    {
        StreamReader SR = new StreamReader(Path, Encoding.Default);
        String Line;

        while ((Line = SR.ReadLine()) != null)
        {
            LocationName.Add(Line.ToString());
            LocationNameCopy.Add(Line.ToString());
        }
    }

    public string GetEachChar(string EachLocationName)
    {
        string EachFirstLetter = "";
        string FirstLetterConcat = "";
        int LocationNameLength = EachLocationName.Length;

        for (int i=0; i< LocationNameLength; i++)
        {
            EachFirstLetter = GetCharFirstLetter(EachLocationName.Substring(i, 1));
            FirstLetterConcat += EachFirstLetter;
        }

        return FirstLetterConcat;
    }

    public string GetCharFirstLetter(string EachChar)
    {
        long LetterCode;
        byte[] CurrentChar = System.Text.Encoding.Default.GetBytes(EachChar);

        if (CurrentChar.Length==1)
        {
            return EachChar.ToUpper();
        }
        else
        {
            int i1 = (short)(CurrentChar[0]);
            int i2 = (short)(CurrentChar[1]);
            LetterCode = i1 * 256 + i2;
        }

        if ((LetterCode >= 45217) && (LetterCode <= 45252))
        {
            return "A";
        }
        else if ((LetterCode >= 45253) && (LetterCode <= 45760))
        {
            return "B";
        }
        else if ((LetterCode >= 45761) && (LetterCode <= 46317))
        {
            return "C";
        }
        else if ((LetterCode >= 46318) && (LetterCode <= 46825))
        {
            return "D";
        }
        else if ((LetterCode >= 46826) && (LetterCode <= 47009))
        {
            return "E";
        }
        else if ((LetterCode >= 47010) && (LetterCode <= 47296))
        {
            return "F";
        }
        else if ((LetterCode >= 47297) && (LetterCode <= 47613))
        {
            return "G";
        }
        else if ((LetterCode >= 47614) && (LetterCode <= 48118))
        {
            return "H";
        }
        else if ((LetterCode >= 48119) && (LetterCode <= 49061))
        {
            return "J";
        }
        else if ((LetterCode >= 49062) && (LetterCode <= 49323))
        {
            return "K";
        }
        else if ((LetterCode >= 49324) && (LetterCode <= 49895))
        {
            return "L";
        }
        else if ((LetterCode >= 49896) && (LetterCode <= 50370))
        {
            return "M";
        }
        else if ((LetterCode >= 50371) && (LetterCode <= 50613))
        {
            return "N";
        }
        else if ((LetterCode >= 50614) && (LetterCode <= 50621))
        {
            return "O";
        }
        else if ((LetterCode >= 50622) && (LetterCode <= 50905))
        {
            return "P";
        }
        else if ((LetterCode >= 50906) && (LetterCode <= 51386))
        {
            return "Q";
        }
        else if ((LetterCode >= 51387) && (LetterCode <= 51445))
        {
            return "R";
        }
        else if ((LetterCode >= 51446) && (LetterCode <= 52217))
        {
            return "S";
        }
        else if ((LetterCode >= 52218) && (LetterCode <= 52697))
        {
            return "T";
        }
        else if ((LetterCode >= 52698) && (LetterCode <= 52979))
        {
            return "W";
        }
        else if ((LetterCode >= 52980) && (LetterCode <= 53640))
        {
            return "X";
        }
        else if ((LetterCode >= 53689) && (LetterCode <= 54480))
        {
            return "Y";
        }
        else if ((LetterCode >= 54481) && (LetterCode <= 55289))
        {
            return "Z";
        }
        else
        {
            return ("?");
        }    
    }

    public void GetIndex(List<string> LocationName, string SearchValue)
    {
        int CurrentValue = 0;
        int ReturnValue = 0;

        NewLocationNamesList.Clear();
        IndexList.Clear();

        for (int n = 0; n < LocationName.Count; n++)
        {
            ReturnValue = LocationName[n].IndexOf(SearchValue);
            if (ReturnValue > -1)
            {
                IndexList.Add(n);
                CurrentValue++;
            }
        }
        for (int n = 0; n < IndexList.Count; n++)
        {
            NewLocationNamesList.Add(LocationNamesList[IndexList[n]]);
        }
    }
}
