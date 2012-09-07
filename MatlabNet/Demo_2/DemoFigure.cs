/*
* MATLAB Compiler: 4.17 (R2012a)
* Date: Mon Aug 20 10:29:16 2012
* Arguments: "-B" "macro_default" "-W" "dotnet:Demo1,DemoMagic,4.0,private" "-T"
* "link:lib" "-d" "D:\MatlabForCSharpDemo\Demo1\Demo1\src" "-C" "-w"
* "enable:specified_file_mismatch" "-w" "enable:repeated_file" "-w"
* "enable:switch_ignored" "-w" "enable:missing_lib_sentinel" "-w" "enable:demo_license"
* "-v" "class{DemoMagic:D:\MatlabForCSharpDemo\Demo1\Demo_GetMagicSquare.m}"
* "class{DemoFigure:D:\MatlabForCSharpDemo\Demo1\Demo_DrawGraph.m}" 
*/
using System;
using System.Reflection;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace Demo2
{

  /// <summary>
  /// The DemoFigure class provides a CLS compliant, MWArray interface to the M-functions
  /// contained in the files:
  /// <newpara></newpara>
  /// D:\MatlabForCSharpDemo\Demo1\Demo_DrawGraph.m
  /// </summary>
  /// <remarks>
  /// @Version 4.0
  /// </remarks>
  public class DemoFigure : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static DemoFigure()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        mcr= new MWMCR("Demo1",
                       ctfFilePath, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the DemoFigure class.
    /// </summary>
    public DemoFigure()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~DemoFigure()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the Demo_DrawGraph
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 注意命名都是大小写，是为了符合.NET的命名规范
    /// Matlab大小写是敏感的
    /// 输入是x序列和y序列
    /// </remarks>
    ///
    public void Demo_DrawGraph()
    {
      mcr.EvaluateFunction(0, "Demo_DrawGraph", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the Demo_DrawGraph
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 注意命名都是大小写，是为了符合.NET的命名规范
    /// Matlab大小写是敏感的
    /// 输入是x序列和y序列
    /// </remarks>
    /// <param name="x">Input argument #1</param>
    ///
    public void Demo_DrawGraph(MWArray x)
    {
      mcr.EvaluateFunction(0, "Demo_DrawGraph", x);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the Demo_DrawGraph
    /// M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 注意命名都是大小写，是为了符合.NET的命名规范
    /// Matlab大小写是敏感的
    /// 输入是x序列和y序列
    /// </remarks>
    /// <param name="x">Input argument #1</param>
    /// <param name="y">Input argument #2</param>
    ///
    public void Demo_DrawGraph(MWArray x, MWArray y)
    {
      mcr.EvaluateFunction(0, "Demo_DrawGraph", x, y);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the Demo_DrawGraph M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 注意命名都是大小写，是为了符合.NET的命名规范
    /// Matlab大小写是敏感的
    /// 输入是x序列和y序列
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Demo_DrawGraph(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Demo_DrawGraph", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the Demo_DrawGraph M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 注意命名都是大小写，是为了符合.NET的命名规范
    /// Matlab大小写是敏感的
    /// 输入是x序列和y序列
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="x">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Demo_DrawGraph(int numArgsOut, MWArray x)
    {
      return mcr.EvaluateFunction(numArgsOut, "Demo_DrawGraph", x);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the Demo_DrawGraph M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 注意命名都是大小写，是为了符合.NET的命名规范
    /// Matlab大小写是敏感的
    /// 输入是x序列和y序列
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="x">Input argument #1</param>
    /// <param name="y">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Demo_DrawGraph(int numArgsOut, MWArray x, MWArray y)
    {
      return mcr.EvaluateFunction(numArgsOut, "Demo_DrawGraph", x, y);
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
