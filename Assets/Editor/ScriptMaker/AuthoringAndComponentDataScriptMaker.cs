using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;


namespace ScriptMaker
{

    public static class PathStrings
    {
        public static readonly string AuthoringAndComponentDataPath = "AuthoringNComponentDataTemplate.txt";
        public static readonly string AuthoringPath = "AuthoringTemplate.txt";
        public static readonly string AspectPath = "AspectTemplate.txt";
        public static readonly string ComponentDataPath = "ComponentDataTemplate.txt";
        public static readonly string TemplatePath = "CustomScriptTemplates";


    }

    public class AuthoringAndComponentDataScriptMaker : EndNameEditAction
    {

        [MenuItem("Assets/ECS/Create/Authoring N Component", priority = 1)]
        public static void CreateUI()
        {
            var path = Path.Combine(Application.dataPath, PathStrings.TemplatePath, PathStrings.AuthoringAndComponentDataPath);

            var file = File.ReadAllText(path);
            var asset = new TextAsset(file);
            //file.Replace("[CustomUIForm]", )
            Debug.Log(file);

            Texture2D csIcon =
                EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;

            var endNameEditAction =
                ScriptableObject.CreateInstance<AuthoringAndComponentDataScriptMaker>();

            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
                endNameEditAction, "New Authoring.cs", csIcon, path);



        }

        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            var text = File.ReadAllText(resourceFile);

            var className = Path.GetFileNameWithoutExtension(pathName);

            className = className.Replace(" ", "");
            text = text.Replace("[ScriptName]", className);
            var encoding = new UTF8Encoding(true, false);

            pathName = Path.Combine(Path.GetDirectoryName(pathName), $"{className}Authoring.cs");
            File.WriteAllText(pathName, text, encoding);
            
            AssetDatabase.ImportAsset(pathName);
            var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
            ProjectWindowUtil.ShowCreatedAsset(asset);
        }
    }


    public class AuthoringScriptMaker : EndNameEditAction
    {

        [MenuItem("Assets/ECS/Create/Authoring", priority = 1)]
        public static void CreateUI()
        {
            var path = Path.Combine(Application.dataPath, PathStrings.TemplatePath, PathStrings.AuthoringPath);

            var file = File.ReadAllText(path);
            var asset = new TextAsset(file);
            //file.Replace("[CustomUIForm]", )
            Debug.Log(file);

            Texture2D csIcon =
                EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;

            var endNameEditAction =
                ScriptableObject.CreateInstance<AuthoringAndComponentDataScriptMaker>();

            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
                endNameEditAction, "New Authoring.cs", csIcon, path);



        }

        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            var text = File.ReadAllText(resourceFile);

            var className = Path.GetFileNameWithoutExtension(pathName);

            className = className.Replace(" ", "");
            text = text.Replace("[ScriptName]", className);
            var encoding = new UTF8Encoding(true, false);

            pathName = Path.Combine(Path.GetDirectoryName(pathName), $"{className}Authoring.cs");
            File.WriteAllText(pathName, text, encoding);

            AssetDatabase.ImportAsset(pathName);
            var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
            ProjectWindowUtil.ShowCreatedAsset(asset);
        }
    }

    public class ComponentDataScriptMaker : EndNameEditAction
    {

        [MenuItem("Assets/ECS/Create/Component", priority = 1)]
        public static void CreateUI()
        {
            var path = Path.Combine(Application.dataPath, PathStrings.TemplatePath, PathStrings.ComponentDataPath);

            var file = File.ReadAllText(path);
            var asset = new TextAsset(file);
            //file.Replace("[CustomUIForm]", )
            Debug.Log(file);

            Texture2D csIcon =
                EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;

            var endNameEditAction =
                ScriptableObject.CreateInstance<AuthoringAndComponentDataScriptMaker>();

            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
                endNameEditAction, "New ComponentData.cs", csIcon, path);



        }

        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            var text = File.ReadAllText(resourceFile);

            var className = Path.GetFileNameWithoutExtension(pathName);

            className = className.Replace(" ", "");
            text = text.Replace("[ScriptName]", className);
            var encoding = new UTF8Encoding(true, false);

            pathName = Path.Combine(Path.GetDirectoryName(pathName), $"{className}ComponentData.cs");
            File.WriteAllText(pathName, text, encoding);

            AssetDatabase.ImportAsset(pathName);
            var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
            ProjectWindowUtil.ShowCreatedAsset(asset);
        }
    }


    public class AspectScriptMaker : EndNameEditAction
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

            pathName = Path.Combine(Path.GetDirectoryName(pathName), $"{className}Authoring.cs");
            File.WriteAllText(pathName, text, encoding);

            AssetDatabase.ImportAsset(pathName);
            var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
            ProjectWindowUtil.ShowCreatedAsset(asset);
        }
    }




}