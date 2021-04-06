/*
* Copyright 2008 ZXing authors
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Text;

namespace GHIElectronics.TinyCLR.Drivers.Barcode.QrCode.Internal
{
   /// <author>satorux@google.com (Satoru Takabayashi) - creator</author>
   /// <author>dswitkin@google.com (Daniel Switkin) - ported from C++</author>
   public sealed class QRCode
   {
      public static int NUM_MASK_PATTERNS = 8;

      public QRCode()
      {
            this.MaskPattern = -1;
      }

      public Mode Mode { get; set; }

      public ErrorCorrectionLevel ECLevel { get; set; }

      public Version Version { get; set; }

      public int MaskPattern { get; set; }

      public ByteMatrix Matrix { get; set; }

      public override string ToString()
      {
         var result = new StringBuilder(200);
         result.Append("<<\n");
         result.Append(" mode: ");
         result.Append(this.Mode);
         result.Append("\n ecLevel: ");
         result.Append(this.ECLevel);
         result.Append("\n version: ");
         if (this.Version == null)
            result.Append("null");
         else
            result.Append(this.Version);
         result.Append("\n maskPattern: ");
         result.Append(this.MaskPattern);
         if (this.Matrix == null)
         {
            result.Append("\n matrix: null\n");
         }
         else
         {
            result.Append("\n matrix:\n");
            result.Append(this.Matrix.ToString());
         }
         result.Append(">>\n");
         return result.ToString();
      }

      // Check if "mask_pattern" is valid.
      public static bool isValidMaskPattern(int maskPattern)
      {
         return maskPattern >= 0 && maskPattern < NUM_MASK_PATTERNS;
      }
   }
}
