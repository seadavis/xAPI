﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Clients;
using xAPI.Processes;

namespace xAPI.Fixtures
{
   // Base class for fixtures involving an
   // HttpClient
   public class HttpClientFixture : IDisposable
   {
      #region Private Variables

      private ProcessRunner _runner;

      #endregion

      #region Properties

      public IHttpClient Client { get => new xAPIHttpClient(_runner.Client); }

      #endregion

      #region Constructor

      /// <summary>
      /// Starts the ASP.Net process and builds the corresponding HttpClient.
      /// </summary>
      /// <param name="projectPath">The path to the .NET project that we
      /// wish to start up as a requirement for the test.
      /// 
      /// Should be the folder without the path
      /// Example:
      /// <code>
      /// HttpClientFixture(@"C:\Source\ASPProject")
      /// </code>
      /// 
      /// </param>
      public HttpClientFixture(string projectPath)
      {
         _runner = new ProcessRunner(projectPath);
         _runner.Start();
      }


      #endregion

      #region IDispoable

      public void Dispose()
      {
         _runner.Kill();
      }

      #endregion

   }
}