﻿using GameEngineProject.Libraries.AutoDocumentation;
using GameEngineProject.Source.Core;
using GameEngineProject.Source.Entities;
using static System.Net.WebRequestMethods;

namespace GameEngineProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            AutoDocumentation.SourceNamespace = "GameEngineProject.Source";
            AutoDocumentation.SourceDirectory = "C:\\Users\\Thiago\\source\\repos\\GameEngineProject\\Source\\";
            AutoDocumentation.DocsRootDirectory = "C:\\Users\\Thiago\\source\\repos\\GameEngineProject\\docs\\";
            AutoDocumentation.GithubPagesLink = "https://thiagomvas.github.io/GameEngine/";
            AutoDocumentation.GenerateAutoDocumentation();
            //Console.WriteLine(AutoDocumentation.GetListOfTypes());
            //Engine.Setup();


        }
    }
}