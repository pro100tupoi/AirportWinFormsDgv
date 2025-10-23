using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportWinFormsDgv.Classes
{
    /// <summary>
    /// Тип самолёта
    /// </summary>
    public enum Aircrafttype : byte
    {
        /// <summary>
        /// Не известно
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Боинг
        /// </summary>
        Boeing = 1,

        /// <summary>
        /// Эйрбас
        /// </summary>
        Airbus = 2,

        /// <summary>
        /// ОАК
        /// </summary>
        UAC = 3
    }
}
