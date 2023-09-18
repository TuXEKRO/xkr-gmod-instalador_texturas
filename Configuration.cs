// GmodTexurasCsharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// GmodTexurasCsharp.Program

namespace GmodTexurasCsharp
{
    internal class Configuration
    {
        public string htmlUrl { get; private set; }
        public string texturesUrl { get; private set; }

        public Configuration()
        {
            htmlUrl = "https://xekro.com/resources/textures/main.html";
            texturesUrl = "https://xekro.com/resources/textures/CSSContent_Jun2018.zip";
        }
    }
}