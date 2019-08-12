using UnityEngine;
using UnityEditor;

namespace Google2u
{
	[CustomEditor(typeof(CardPrestige))]
	public class CardPrestigeEditor : Editor
	{
		public int Index = 0;
		public override void OnInspectorGUI ()
		{
			CardPrestige s = target as CardPrestige;
			CardPrestigeRow r = s.Rows[ Index ];

			EditorGUILayout.BeginHorizontal();
			if ( GUILayout.Button("<<") )
			{
				Index = 0;
			}
			if ( GUILayout.Button("<") )
			{
				Index -= 1;
				if ( Index < 0 )
					Index = s.Rows.Count - 1;
			}
			if ( GUILayout.Button(">") )
			{
				Index += 1;
				if ( Index >= s.Rows.Count )
					Index = 0;
			}
			if ( GUILayout.Button(">>") )
			{
				Index = s.Rows.Count - 1;
			}

			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.LabelField( s.rowNames[ Index ] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Question_Type", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Question_Type );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Scenario_ID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._Scenario_ID );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Scenario_Text", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Scenario_Text );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Character_Type", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Character_Type );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Extra_IMG_Type", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Extra_IMG_Type );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Choice_RNG", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._Choice_RNG );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CT_Text", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._CT_Text );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CT_Knowledge", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._CT_Knowledge );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CT_SS", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._CT_SS );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CT_Money", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._CT_Money );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CT_Prestige", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._CT_Prestige );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CF_Text", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._CF_Text );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CF_Knowledge", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._CF_Knowledge );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CF_SS", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._CF_SS );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CF_Money", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._CF_Money );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_CF_Prestige", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._CF_Prestige );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.EndHorizontal();

		}
	}
}
