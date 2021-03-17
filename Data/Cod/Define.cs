using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wadatsumi.Data.Cod
{
    public enum Map
    {
        None,
        Cartel,
    }

    public enum Mode
    {
        None,
        Domination,
        HardPoint,
        CombinedArmsDomination,
        CombinedArmsHardPoint,
    }

    public enum Result
    {
        None,
        Win,
        Loss
    }

    public static class EnumHelper
    {
        public static Map GetMap(string maptext) => maptext switch
        {
            "map_cartel" => Map.Cartel,
            _ => Map.None,
        };

        public static Mode GetMode(string modetext) => modetext switch
        {
            "dom" => Mode.Domination,
            _ => Mode.None
        };

        public static Result GetResult(string resulttext) => resulttext switch
        {
            "win" => Result.Win,
            "loss" => Result.Loss,
            _ => Result.None,
        };
    }
}
