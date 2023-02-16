using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScriptMaker;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class AuthoringScriptMaker : EndNameEditAction
{
    [MenuItem("Assets/ECS/Create/Aspect", priority = 1)]
    public static void CreateUI()
    {
        var path = Path.Combine(Application.dataPath, PathStrings.TemplatePath, PathStrings.AspectPath);

        var file = File.ReadAllText(path);
        var asset = new TextAsset(file);
        //file.Replace("[CustomUIForm]", )
        Debug.Log(file);

        Texture2D csIcon =
            EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;

        var endNameEditAction =
            ScriptableObject.CreateInstance<AuthoringAndComponentDataScriptMaker>();

        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
            endNameEditAction, "New Aspect.cs", csIcon, path);



    }

    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var text = File.ReadAllText(resourceFile);

        var className = Path.GetFileNameWithoutExtension(pathName);

        className = className.Replace(" ", "");
        text = text.Replace("[ScriptName]", className);
        var encoding = new UTF8Encoding(true, false);

        pathName = Path.Combine(Path.GetDirectoryName(pathName), $"{className}Aspect.cs");
        File.WriteAllText(pathName, text, encoding);

        AssetDatabase.ImportAsset(pathName);
        var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
        ProjectWindowUtil.ShowCreatedAsset(asset);
    }
}
