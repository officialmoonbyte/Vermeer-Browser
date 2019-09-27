using System;
using System.Collections.Generic;

namespace VermeerApi.History
{
    public class HistoryItem
    {
        public DateTime Date;
        public string Url;
        public string WebsiteTitle;

        #region Internal Vars

        static string Seperator = "%^20^%";
        static string internalSeperator = "%#40#%";

        #endregion Internal Vars

        #region Private Methods

        #region ToString

        public static string ToString(HistoryItem historyItem)
        { string returnString = historyItem.Date.ToString() + internalSeperator + historyItem.Url + internalSeperator + historyItem.WebsiteTitle + Seperator; return returnString; }

        #endregion ToString

        #region ToList

        public static List<HistoryItem> ToList(string HistoryString)
        {
            List<HistoryItem> returnList = new List<HistoryItem>();
            Array calculateArray = HistoryString.Split(new string[] { Seperator }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in calculateArray)
            { returnList.Add(ToObject(s)); }

            return returnList;
        }

        #endregion ToList

        #region ToObject

        public static HistoryItem ToObject(string HistoryString)
        {
            HistoryItem NewHistoryItem = new HistoryItem();
            String[] calculateArray = HistoryString.Split(new string[] { internalSeperator }, StringSplitOptions.None);

            NewHistoryItem.Date = DateTime.Parse(calculateArray[0]);
            NewHistoryItem.Url = calculateArray[1];
            NewHistoryItem.WebsiteTitle = calculateArray[2];

            return NewHistoryItem;
        }

        #endregion ToObject

        #endregion Private Methods

    }
}
