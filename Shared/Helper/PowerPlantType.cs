﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Helper
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PowerPlantType
    {
        Gasfired, Turbojet, windturbine
    }
}
