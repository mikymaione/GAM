/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace GAMSharp.UI.Controlli
{
    class ucCaseTypeTextBox : TextBox
    {

        private bool DisableChange = false;

        public enum eCaseType
        {
            TitleCase,
            TitleCaseSaint,
            Upper,
            Lower
        }

        [DefaultValue(eCaseType.TitleCase), Browsable(true)]
        public eCaseType CaseType { get; set; }

        public ucCaseTypeTextBox()
        {
            TextChanged += UcTextBoxEX_TextChanged;
        }

        private void UcTextBoxEX_TextChanged(object sender, System.EventArgs e)
        {
            if (!DisableChange)
            {
                DisableChange = true;
                int sel_start = SelectionStart;
                int sel_length = SelectionLength;

                CultureInfo culture_info = Thread.CurrentThread.CurrentCulture;
                TextInfo text_info = culture_info.TextInfo;

                if (CaseType == eCaseType.TitleCase)
                    Text = text_info.ToTitleCase(Text);
                else if (CaseType == eCaseType.Upper)
                    Text = text_info.ToUpper(Text);
                else if (CaseType == eCaseType.Lower)
                    Text = text_info.ToLower(Text);
                else if (CaseType == eCaseType.TitleCaseSaint)
                {
                    Text = text_info.ToTitleCase(Text);

                    for (int i = 0; i < Text.Length; i++)
                        if (Text[i] == '\'')
                            if (i + 1 < Text.Length)
                            {
                                string da = Text.Substring(i, 2);
                                string a = da.ToUpper();

                                Text = Text.Replace(da, a);
                            }
                }

                Select(sel_start, sel_length);
                DisableChange = false;
            }
        }


    }
}