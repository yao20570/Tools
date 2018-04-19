using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dealImage.CommonEnum
{
    public class EnumAttriType
    {
        public const string textures = "textures";
        public const string texturesPng = "texturesPng";
        public const string widgetTree = "widgetTree";
        public const string children = "children";
        public const string options = "options";

        //layer
        public const string fileNameData = "fileNameData";

        //image
        public const string backGroundImageData = "backGroundImageData";

        //Slider
        public const string ballDisabledData = "ballDisabledData";
        public const string ballNormalData = "ballNormalData";
        public const string ballPressedData = "ballPressedData";
        public const string barFileNameData = "barFileNameData";
        public const string progressBarData = "progressBarData";


        public const string path = "path";
        public const string plistFile = "plistFile";


        static List<string> imageKey = new List<string>();

        static public List<string> getImageKeyList()
        {

            if (imageKey.Count == 0)
            {
                imageKey.Add(fileNameData);

                imageKey.Add(backGroundImageData);

                imageKey.Add(ballDisabledData);
                imageKey.Add(ballNormalData);
                imageKey.Add(ballPressedData);
                imageKey.Add(barFileNameData);
                imageKey.Add(progressBarData);
            }

            return imageKey;
        }
    }
}
