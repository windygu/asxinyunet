namespace MathWorks.MATLAB.NET.Arrays
{
    using System;
    using System.Reflection;
    using System.Resources;

    internal class MWResources
    {
        private static ResourceManager resourceManager;

        static MWResources()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string str = executingAssembly.GetManifestResourceNames()[0];
            resourceManager = new ResourceManager(str.TrimEnd("resources".ToCharArray()).TrimEnd(".".ToCharArray()), executingAssembly);
        }

        public static ResourceManager getResourceManager() { return resourceManager; }
    }
}
