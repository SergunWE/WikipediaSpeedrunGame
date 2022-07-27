using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WikipediaSpeedrunGame
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
