//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class CardPrestigeRow : IGoogle2uRow
	{
		public string _Question_Type;
		public int _Scenario_ID;
		public string _Scenario_Text;
		public string _Character_Type;
		public string _Extra_IMG_Type;
		public int _Choice_RNG;
		public string _CT_Text;
		public int _CT_Knowledge;
		public int _CT_SS;
		public int _CT_Money;
		public int _CT_Prestige;
		public string _CF_Text;
		public int _CF_Knowledge;
		public int _CF_SS;
		public int _CF_Money;
		public int _CF_Prestige;
		public CardPrestigeRow(string __ID, string __Question_Type, string __Scenario_ID, string __Scenario_Text, string __Character_Type, string __Extra_IMG_Type, string __Choice_RNG, string __CT_Text, string __CT_Knowledge, string __CT_SS, string __CT_Money, string __CT_Prestige, string __CF_Text, string __CF_Knowledge, string __CF_SS, string __CF_Money, string __CF_Prestige) 
		{
			_Question_Type = __Question_Type.Trim();
			{
			int res;
				if(int.TryParse(__Scenario_ID, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Scenario_ID = res;
				else
					Debug.LogError("Failed To Convert _Scenario_ID string: "+ __Scenario_ID +" to int");
			}
			_Scenario_Text = __Scenario_Text.Trim();
			_Character_Type = __Character_Type.Trim();
			_Extra_IMG_Type = __Extra_IMG_Type.Trim();
			{
			int res;
				if(int.TryParse(__Choice_RNG, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Choice_RNG = res;
				else
					Debug.LogError("Failed To Convert _Choice_RNG string: "+ __Choice_RNG +" to int");
			}
			_CT_Text = __CT_Text.Trim();
			{
			int res;
				if(int.TryParse(__CT_Knowledge, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CT_Knowledge = res;
				else
					Debug.LogError("Failed To Convert _CT_Knowledge string: "+ __CT_Knowledge +" to int");
			}
			{
			int res;
				if(int.TryParse(__CT_SS, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CT_SS = res;
				else
					Debug.LogError("Failed To Convert _CT_SS string: "+ __CT_SS +" to int");
			}
			{
			int res;
				if(int.TryParse(__CT_Money, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CT_Money = res;
				else
					Debug.LogError("Failed To Convert _CT_Money string: "+ __CT_Money +" to int");
			}
			{
			int res;
				if(int.TryParse(__CT_Prestige, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CT_Prestige = res;
				else
					Debug.LogError("Failed To Convert _CT_Prestige string: "+ __CT_Prestige +" to int");
			}
			_CF_Text = __CF_Text.Trim();
			{
			int res;
				if(int.TryParse(__CF_Knowledge, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CF_Knowledge = res;
				else
					Debug.LogError("Failed To Convert _CF_Knowledge string: "+ __CF_Knowledge +" to int");
			}
			{
			int res;
				if(int.TryParse(__CF_SS, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CF_SS = res;
				else
					Debug.LogError("Failed To Convert _CF_SS string: "+ __CF_SS +" to int");
			}
			{
			int res;
				if(int.TryParse(__CF_Money, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CF_Money = res;
				else
					Debug.LogError("Failed To Convert _CF_Money string: "+ __CF_Money +" to int");
			}
			{
			int res;
				if(int.TryParse(__CF_Prestige, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CF_Prestige = res;
				else
					Debug.LogError("Failed To Convert _CF_Prestige string: "+ __CF_Prestige +" to int");
			}
		}

		public int Length { get { return 16; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _Question_Type.ToString();
					break;
				case 1:
					ret = _Scenario_ID.ToString();
					break;
				case 2:
					ret = _Scenario_Text.ToString();
					break;
				case 3:
					ret = _Character_Type.ToString();
					break;
				case 4:
					ret = _Extra_IMG_Type.ToString();
					break;
				case 5:
					ret = _Choice_RNG.ToString();
					break;
				case 6:
					ret = _CT_Text.ToString();
					break;
				case 7:
					ret = _CT_Knowledge.ToString();
					break;
				case 8:
					ret = _CT_SS.ToString();
					break;
				case 9:
					ret = _CT_Money.ToString();
					break;
				case 10:
					ret = _CT_Prestige.ToString();
					break;
				case 11:
					ret = _CF_Text.ToString();
					break;
				case 12:
					ret = _CF_Knowledge.ToString();
					break;
				case 13:
					ret = _CF_SS.ToString();
					break;
				case 14:
					ret = _CF_Money.ToString();
					break;
				case 15:
					ret = _CF_Prestige.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "_Question_Type":
					ret = _Question_Type.ToString();
					break;
				case "_Scenario_ID":
					ret = _Scenario_ID.ToString();
					break;
				case "_Scenario_Text":
					ret = _Scenario_Text.ToString();
					break;
				case "_Character_Type":
					ret = _Character_Type.ToString();
					break;
				case "_Extra_IMG_Type":
					ret = _Extra_IMG_Type.ToString();
					break;
				case "_Choice_RNG":
					ret = _Choice_RNG.ToString();
					break;
				case "_CT_Text":
					ret = _CT_Text.ToString();
					break;
				case "_CT_Knowledge":
					ret = _CT_Knowledge.ToString();
					break;
				case "_CT_SS":
					ret = _CT_SS.ToString();
					break;
				case "_CT_Money":
					ret = _CT_Money.ToString();
					break;
				case "_CT_Prestige":
					ret = _CT_Prestige.ToString();
					break;
				case "_CF_Text":
					ret = _CF_Text.ToString();
					break;
				case "_CF_Knowledge":
					ret = _CF_Knowledge.ToString();
					break;
				case "_CF_SS":
					ret = _CF_SS.ToString();
					break;
				case "_CF_Money":
					ret = _CF_Money.ToString();
					break;
				case "_CF_Prestige":
					ret = _CF_Prestige.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "_Question_Type" + " : " + _Question_Type.ToString() + "} ";
			ret += "{" + "_Scenario_ID" + " : " + _Scenario_ID.ToString() + "} ";
			ret += "{" + "_Scenario_Text" + " : " + _Scenario_Text.ToString() + "} ";
			ret += "{" + "_Character_Type" + " : " + _Character_Type.ToString() + "} ";
			ret += "{" + "_Extra_IMG_Type" + " : " + _Extra_IMG_Type.ToString() + "} ";
			ret += "{" + "_Choice_RNG" + " : " + _Choice_RNG.ToString() + "} ";
			ret += "{" + "_CT_Text" + " : " + _CT_Text.ToString() + "} ";
			ret += "{" + "_CT_Knowledge" + " : " + _CT_Knowledge.ToString() + "} ";
			ret += "{" + "_CT_SS" + " : " + _CT_SS.ToString() + "} ";
			ret += "{" + "_CT_Money" + " : " + _CT_Money.ToString() + "} ";
			ret += "{" + "_CT_Prestige" + " : " + _CT_Prestige.ToString() + "} ";
			ret += "{" + "_CF_Text" + " : " + _CF_Text.ToString() + "} ";
			ret += "{" + "_CF_Knowledge" + " : " + _CF_Knowledge.ToString() + "} ";
			ret += "{" + "_CF_SS" + " : " + _CF_SS.ToString() + "} ";
			ret += "{" + "_CF_Money" + " : " + _CF_Money.ToString() + "} ";
			ret += "{" + "_CF_Prestige" + " : " + _CF_Prestige.ToString() + "} ";
			return ret;
		}
	}
	public class CardPrestige :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			Personnel_1, Personnel_2, Personnel_3, Personnel_4, Resting_1, Family_1, Family_2, Facilitation_1, Competency_1, Provisions_1
		};
		public string [] rowNames = {
			"Personnel_1", "Personnel_2", "Personnel_3", "Personnel_4", "Resting_1", "Family_1", "Family_2", "Facilitation_1", "Competency_1", "Provisions_1"
		};
		public System.Collections.Generic.List<CardPrestigeRow> Rows = new System.Collections.Generic.List<CardPrestigeRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new CardPrestigeRow(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7],input[8],input[9],input[10],input[11],input[12],input[13],input[14],input[15],input[16]));
		}
		public override void Clear ()
		{
			Rows.Clear();
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public CardPrestigeRow GetRow(rowIds in_RowID)
		{
			CardPrestigeRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public CardPrestigeRow GetRow(string in_RowString)
		{
			CardPrestigeRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
