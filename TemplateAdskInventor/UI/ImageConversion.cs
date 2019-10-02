//////////////////////////////////////////////////////////////////////
//
// DO NOT CANCEL THIS PART
// Author: Paolo Cappelletto
// e-mail: p.cappelletto@maffeis.it
// skype4B: p.cappelletto@maffeis.it
//
// Copyright:
// Maffeis Enginnering
// Via Mignano 26 
// 36020 Solagna (VI) - ITALY
// http://www.maffeis.it/ - info@maffeis.it
//
//////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TemplateAdskInventor.UI
{
    public class ImageConversion : AxHost
    {
        private ImageConversion() : base(String.Empty)
        {
        }

        public static stdole.IPictureDisp ImageToPictureDisp(Image _image)
        {
            return (stdole.IPictureDisp)GetIPictureFromPicture(_image);
        }

        public static Image PictureDispToImage(stdole.IPictureDisp _pict_disp)
        {
            return GetPictureFromIPicture(_pict_disp);
        }

    }
}
