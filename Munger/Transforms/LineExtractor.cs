﻿using System.Collections.Generic;
using System.IO;

namespace Munger.Transforms
{
 public   class LineExtractor:StringTransform
    {
        public override List<string> Transform(string text)
        {
            var lines = new List<string>();


            using (var sr = new StringReader(text))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    lines.Add(line);
            }
            return lines;
        }
    }
}