using System;
using UnityEngine;

namespace xOrfe.Utilities
{
	public static class GUIDUtility
	{
		public static string GetUniqueID(bool generateNewIDState = false)
		{
			string uniqueID;

			if (PlayerPrefsUtility.HasKey("guid") && !generateNewIDState)
			{
				uniqueID = PlayerPrefsUtility.getString("guid");
			}
			else
			{
				uniqueID = generateGUID();
				PlayerPrefsUtility.SetString("guid", uniqueID);
			}

			return uniqueID;
		}

		public static string generateGUID()
		{
			var random = new System.Random();
			DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
			double timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;

			string uniqueID = String.Format("{0:X}", Convert.ToInt32(timestamp))
			                  + "-" + String.Format("{0:X}", random.Next(1000000000))
			                  + "-" + String.Format("{0:X}", random.Next(1000000000))
			                  +"-" + String.Format("{0:X}", random.Next(1000000000))
			                  +"-" + String.Format("{0:X}", random.Next(1000000000));

			Debug.Log(uniqueID);

			return uniqueID;
		}

	}
}
