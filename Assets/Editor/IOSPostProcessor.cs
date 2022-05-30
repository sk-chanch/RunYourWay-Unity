using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;
using System.Collections.Generic;
using System;

public class IOSPostProcessor
{

    static string directory = "";

    private static string editorBy = "//Edit by: Chan MZ -> IOSPostProcessor.cs";

    private static string wordReplace = @"#if (PLATFORM_IOS && defined(__IPHONE_13_0)) || (PLATFORM_TVOS && defined(__TVOS_13_0))
    if (@available(iOS 13, tvOS 13, *))
        _window = [[UIWindow alloc] initWithWindowScene: [self pickStartupWindowScene: application.connectedScenes]];
    else
#endif";
   

    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (target != BuildTarget.iOS)
            return;
        string fileName = "UnityAppController.mm";
        string editPath = "/Classes/" + fileName;


        if (File.Exists(pathToBuiltProject + editPath)) {
            directory = pathToBuiltProject + "/Classes/";

            EditorialResponse(
                fileName,
                wordReplace,
                editorBy,
                fileName);

         
            
        }
       
        
    }

   

    public static void EditorialResponse(string fileName,
        string word,
        string replacement,
        string saveFileName)
    {
        var reader = new StreamReader(directory + fileName);
        var input = reader.ReadToEnd();

        File.Delete(directory + saveFileName);

        using (var writer = new StreamWriter(directory + saveFileName, true))
        {
            {
               
                string output = input.Replace(word, replacement);
                writer.Write(output);
            }
            writer.Close();
        }
    }


}
